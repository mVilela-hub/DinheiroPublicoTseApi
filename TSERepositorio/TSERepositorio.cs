using Microsoft.Extensions.Caching.Memory;
using System.Globalization;
using TSERepositorio.DTOs;

namespace TSERepositorio;

public class TSERepositorio : BaseRepositorio, ITSERepositorio
{
    private readonly IMemoryCache _cache;

    public TSERepositorio(IMemoryCache cache) : base(cache)
    {
        _cache = cache;
    }

    public List<Candidato> MaiorReceitaPublicaCandidatoResult(string cidade)
    {
        List<Candidato> resultCandidatos = new();
        ReceitasCandidato[] receitaCandidatos = CarregaBaseDeDados();

        resultCandidatos.AddRange(GroupByMaiorReceitaPublica(cidade, receitaCandidatos, 10, "Vereador"));

        resultCandidatos.Add(GroupByMaiorReceitaPublica(cidade, receitaCandidatos, 1, "Prefeito").First());
        

        return resultCandidatos.ToList();
    }

    public List<Candidato> MaiorReceitaPublicaCandidatoTodasCapitaisResult()
    {
        List<Candidato>? resultCandidatos = new();
        var capitaisBrasileiras = CapitaisBrasileiras.Capitais;
        ReceitasCandidato[] receitaCandidatos = CarregaBaseDeDados();

        if (!_cache.TryGetValue(cacheKeyCapitais, out resultCandidatos))
        {
            if (resultCandidatos == null)
                resultCandidatos = new List<Candidato>();

            capitaisBrasileiras.ForEach(capital =>
            {
                var vereadores = GroupByMaiorReceitaPublica(capital, receitaCandidatos, 10, "Vereador");
                var prefeito = GroupByMaiorReceitaPublica(capital, receitaCandidatos, 1, "Prefeito").First();

                resultCandidatos.AddRange(vereadores);
                resultCandidatos.Add(prefeito);
            });

            _cache.Set(cacheKeyCapitais, resultCandidatos);
        }


        return resultCandidatos ?? new List<Candidato>();
    }

    public string GastoTotalPorCidade(string cidade)
    {
        ReceitasCandidato[] receitaCandidatos = CarregaBaseDeDados();

        decimal gastosTotalPorCidade = receitaCandidatos.Where(rc => rc.NM_UE?.ToLower() == cidade.ToLower() && 
                                                        (rc.CD_FONTE_RECEITA == (int)EnumFonteReceita.FundoEspecial || 
                                                         rc.CD_FONTE_RECEITA == (int)EnumFonteReceita.FundoPartidario))
                                                        .Sum(t => t.VR_RECEITA);

        return DecimalParaReais(gastosTotalPorCidade);
    }

    public string GastoTotalDoBrasil()
    {
        ReceitasCandidato[] receitaCandidatos = CarregaBaseDeDados();

        decimal gastosTotalPorCidade = receitaCandidatos.Where(rc => (rc.CD_FONTE_RECEITA == (int)EnumFonteReceita.FundoEspecial ||
                                                         rc.CD_FONTE_RECEITA == (int)EnumFonteReceita.FundoPartidario))
                                                        .Sum(t => t.VR_RECEITA);

        return DecimalParaReais(gastosTotalPorCidade);
    }


    private static IEnumerable<Candidato> GroupByMaiorReceitaPublica(string cidade, ReceitasCandidato[] receitaCandidatos, int numeroRetorno, string cargo)
    {
        return receitaCandidatos.Where(rc => rc.NM_UE?.ToLower() == cidade.ToLower() && 
                                    rc.DS_CARGO == cargo && 
                                   (rc.CD_FONTE_RECEITA == (int)EnumFonteReceita.FundoEspecial || 
                                    rc.CD_FONTE_RECEITA == (int)EnumFonteReceita.FundoPartidario))
                                    .GroupBy(rc => new 
                                    {
                                        rc.NM_CANDIDATO,
                                        rc.NR_CPF_CANDIDATO
                                    })
                                    .Select(c => new Candidato
                                    {
                                        Nome = c.Key.NM_CANDIDATO,
                                        ReceitaPublicaInvestida = c.Sum(t => t.VR_RECEITA),
                                        SiglaDoPartido = c.Select(c => c.SG_PARTIDO).FirstOrDefault(),
                                        NomeDoPartido = c.Select(c => c.NM_PARTIDO).FirstOrDefault(),
                                        DescricaoDoCargo = c.Select(c => c.DS_CARGO).FirstOrDefault(),
                                        Cidade = c.Select(c => c.NM_UE).FirstOrDefault(),
                                        UF = c.Select(c => c.SG_UF).FirstOrDefault(),
                                        NumeroCandidato = c.Select(c => c.NR_CANDIDATO).FirstOrDefault(),
                                        ReceitaPublicaFormatada = DecimalParaReais(c.Sum(t => t.VR_RECEITA))
                                    })
                                    .OrderByDescending(c => c.ReceitaPublicaInvestida)
                                    .Take(numeroRetorno);
    }

    private static string DecimalParaReais(decimal valor)
    {
        decimal valorDecimal;

        //if (valor >= 10000000000)
        //    valorDecimal = valor / 1000.0m;
        //else
        valorDecimal = valor / 100.0m;
 
        return valorDecimal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
    }
}
