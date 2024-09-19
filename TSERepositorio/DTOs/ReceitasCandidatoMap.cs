using CsvHelper.Configuration;


namespace TSERepositorio.DTOs;

public class ReceitasCandidatoMap : ClassMap<ReceitasCandidato>
{
    public ReceitasCandidatoMap()
    {
        Map(rc => rc.SG_UF).Index(12).Name("SG_UF");
        Map(rc => rc.SG_UE).Index(13).Name("SG_UE");
        Map(rc => rc.NM_UE).Index(14).Name("NM_UE");
        Map(rc => rc.DS_CARGO).Index(17).Name("DS_CARGO");
        Map(rc => rc.SQ_CANDIDATO).Index(18).Name("SQ_CANDIDATO");
        Map(rc => rc.NR_CANDIDATO).Index(19).Name("NR_CANDIDATO");
        Map(rc => rc.NM_CANDIDATO).Index(20).Name("NM_CANDIDATO");
        Map(rc => rc.NR_CPF_CANDIDATO).Index(21).Name("NR_CPF_CANDIDATO");
        Map(rc => rc.NR_CPF_VICE_CANDIDATO).Index(22).Name("NR_CPF_VICE_CANDIDATO");
        Map(rc => rc.NR_PARTIDO).Index(23).Name("NR_PARTIDO");
        Map(rc => rc.SG_PARTIDO).Index(24).Name("SG_PARTIDO");
        Map(rc => rc.NM_PARTIDO).Index(25).Name("NM_PARTIDO");
        Map(rc => rc.CD_FONTE_RECEITA).Index(26).Name("CD_FONTE_RECEITA");
        Map(rc => rc.VR_RECEITA).Index(56).Name("VR_RECEITA");

    }
}
