using Microsoft.AspNetCore.Mvc;
using FitControl_API.Models;
using FitControl_API.Services;

namespace FitControl_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TreinosController : ControllerBase
{
    private readonly ITreinoService _treinoService;

    public TreinosController(ITreinoService treinoService)
    {
        _treinoService = treinoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTreinos()
    {
        var treinos = await _treinoService.ObterTreinosAsync();
        return Ok(treinos);
    }

    [HttpPost]
    public async Task<IActionResult> PostTreino([FromBody] Treino treino)
    {
        try
        {
            // O Service aplica a regra de negócio: Aluno precisa estar matriculado.
            await _treinoService.CriarFichaTreinoAsync(treino);
            return CreatedAtAction(nameof(GetTreinos), new { id = treino.TreinoId }, treino);
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }
}
