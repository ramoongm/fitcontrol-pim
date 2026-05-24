using Microsoft.AspNetCore.Mvc;
using FitControl_API.Models;
using FitControl_API.Repositories;

namespace FitControl_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlanosController : ControllerBase
{
    private readonly IPlanoRepository _planoRepository;

    public PlanosController(IPlanoRepository planoRepository)
    {
        _planoRepository = planoRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetPlanos()
    {
        var planos = await _planoRepository.ObterTodosAsync();
        return Ok(planos);
    }

    [HttpPost]
    public async Task<IActionResult> PostPlano([FromBody] Plano plano)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _planoRepository.CadastrarAsync(plano);
        return Ok(new { status = "sucesso", mensagem = "Plano cadastrado com sucesso" });
    }
}
