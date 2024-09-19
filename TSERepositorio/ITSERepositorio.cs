using TSERepositorio.DTOs;
namespace TSERepositorio;

public interface ITSERepositorio
{
    List<Candidato> MaiorReceitaPublicaCandidatoResult(string cidade);
    List<Candidato> MaiorReceitaPublicaCandidatoTodasCapitaisResult();
    string GastoTotalPorCidade(string cidade);
    string GastoTotalDoBrasil();
}
