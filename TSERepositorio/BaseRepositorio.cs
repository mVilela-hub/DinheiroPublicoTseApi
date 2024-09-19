using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Caching.Memory;
using System.Globalization;
using System.Text;
using global::TSERepositorio.DTOs;

namespace TSERepositorio;
public abstract class BaseRepositorio
{
    protected string CaminhoArquivo = BuscaCaminhoDaSolucao();
    protected static string cacheKeyReceitas = "c3c15662-2f7a-4fc1-b65c-9b3fa234855d";
    protected static string cacheKeyCapitais = "88f9fc25-b4e5-4288-b352-f92e07d7b5f9";
    private readonly IMemoryCache _cache;

    protected BaseRepositorio(IMemoryCache cache)
    {
        _cache = cache;
    }

    private static string BuscaCaminhoDaSolucao()
    {
        string diretorioBase = AppDomain.CurrentDomain.BaseDirectory;

        string caminhoSolucao = Path.GetFullPath(Path.Combine(diretorioBase, @"..\..\"));

        string caminhoCsv = Path.Combine(caminhoSolucao, "receitas_candidatos_2024_BRASIL.csv");

        return caminhoCsv;
    }

    protected ReceitasCandidato[] CarregaBaseDeDados()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
            Encoding = Encoding.UTF8,
        };

        if (!_cache.TryGetValue(cacheKeyReceitas, out ReceitasCandidato[]? receitaCandidatos))
        {
            using (var stringReader = new StreamReader(CaminhoArquivo, Encoding.GetEncoding("ISO-8859-1")))
            {
                using (var csv = new CsvReader(stringReader, config))
                {
                    csv.Context.RegisterClassMap<ReceitasCandidatoMap>();

                    receitaCandidatos = csv.GetRecords<ReceitasCandidato>().ToArray();

                    _cache.Set(cacheKeyReceitas, receitaCandidatos);
                }
            }
        }

        return receitaCandidatos ?? Array.Empty<ReceitasCandidato>();
    }

}
