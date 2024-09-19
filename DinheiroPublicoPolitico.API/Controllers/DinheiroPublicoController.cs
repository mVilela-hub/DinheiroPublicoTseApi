using Microsoft.AspNetCore.Mvc;
using TSERepositorio;
using TSERepositorio.DTOs;

namespace DinheiroPublicoPolitico.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DinheiroPublicoController : Controller
{
    private readonly ITSERepositorio _tseRepositorio;

    public DinheiroPublicoController(ITSERepositorio tseRepositorio)
    {
        _tseRepositorio = tseRepositorio;
    }

    [HttpGet]
    public IActionResult SelecionaMaioresGastosPublicosPorCidade([FromQuery] string cidade)
    {
        var candidatos = new List<Candidato>();

        candidatos = _tseRepositorio.MaiorReceitaPublicaCandidatoResult(cidade);

        return Ok(candidatos);
    }

    [HttpGet("Capitais")]
    public IActionResult SelecionaMaioresGastosPublicosTodasCapitais()
    {
        var candidatos = new List<Candidato>();

        candidatos = _tseRepositorio.MaiorReceitaPublicaCandidatoTodasCapitaisResult();

        return Ok(candidatos);
    }

    [HttpGet("TotalGastoPublicoCidade")]
    public IActionResult SelecionaMaioresGastosPublicosTodasCapitais([FromQuery] string cidade)
    {
        return Ok(_tseRepositorio.GastoTotalPorCidade(cidade));
    }    
    
    [HttpGet("TotalGastoPublicoBrasil")]
    public IActionResult SelecionaTotalGastosDoBrasil()
    {
        return Ok(_tseRepositorio.GastoTotalDoBrasil());
    }
}
