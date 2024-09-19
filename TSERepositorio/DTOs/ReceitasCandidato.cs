using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace TSERepositorio.DTOs;

public class ReceitasCandidato
{
    [Name("SG_UF")]
    public string SG_UF { get; set; } = String.Empty;
    [Name("SG_UE")]
    public string SG_UE { get; set; } = String.Empty;
    [Name("NM_UE")]
    public string NM_UE { get; set; } = String.Empty;
    [Name("DS_CARGO")]
    public string DS_CARGO { get; set; } = String.Empty;
    [Name("SQ_CANDIDATO")]
    public string SQ_CANDIDATO { get; set; } = String.Empty;
    [Name("NR_CANDIDATO")]
    public string NR_CANDIDATO { get; set; } = String.Empty;
    [Name("NM_CANDIDATO")]
    public string NM_CANDIDATO { get; set; } = String.Empty;
    [Name("NR_CPF_CANDIDATO")]
    public string NR_CPF_CANDIDATO { get; set; } = String.Empty;
    [Name("NR_CPF_VICE_CANDIDATO")]
    public string NR_CPF_VICE_CANDIDATO { get; set; } = String.Empty;
    [Name("NR_PARTIDO")]
    public string NR_PARTIDO { get; set; } = String.Empty;
    [Name("SG_PARTIDO")]
    public string SG_PARTIDO { get; set; } = String.Empty;
    [Name("NM_PARTIDO")]
    public string NM_PARTIDO { get; set; } = String.Empty;
    [Name("CD_FONTE_RECEITA")]
    public int CD_FONTE_RECEITA { get; set; }
    [Name("VR_RECEITA")]
    public decimal VR_RECEITA { get; set; }

}
