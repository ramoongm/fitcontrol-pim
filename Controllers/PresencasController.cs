using Microsoft.AspNetCore.Mvc;
using FitControl_API.Models;
using FitControl_API.Services;

namespace FitControl_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PresencasController : ControllerBase
{
    private readonly IPresencaService _presencaService;

    public PresencasController(IPresencaService presencaService)
    {
        _presencaService = presencaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPresencas()
    {
        var presencas = await _presencaService.ObterPresencasAsync();
        return Ok(presencas);
    }

    [HttpPost]
    public async Task<IActionResult> PostPresenca([FromBody] Presenca presenca)
    {
        try
        {
            // O Service validará se o aluno possui matrícula ativa antes de registrar a presença.
            await _presencaService.RegistrarPresencaAsync(presenca);
            return CreatedAtAction(nameof(GetPresencas), new { id = presenca.PresencaId }, presenca);
        }
        catch (Exception ex)
        {
            // Retorna HTTP 400 (Bad Request) se a regra de negócio for violada.
            return BadRequest(new { erro = ex.Message });
        }
    }
}
