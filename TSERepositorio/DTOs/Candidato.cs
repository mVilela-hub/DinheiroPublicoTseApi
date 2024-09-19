using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSERepositorio.DTOs;

public class Candidato
{
    public string? Nome { get; set; }
    public decimal ReceitaPublicaInvestida { get; set; }
    public string? SiglaDoPartido { get; set; }
    public string? NomeDoPartido { get; set; }
    public string? DescricaoDoCargo { get; set; }
    public string? Cidade { get; set; }
    public string? UF { get; set; }
    public string? NumeroCandidato { get; set; }
    public string? ReceitaPublicaFormatada { get; set; }

}
