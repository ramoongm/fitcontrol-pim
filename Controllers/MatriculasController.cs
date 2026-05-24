using Microsoft.AspNetCore.Mvc;
using FitControl_API.Models;
using FitControl_API.Services;

namespace FitControl_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatriculasController : ControllerBase
{
    private readonly IMatriculaService _matriculaService;

    public MatriculasController(IMatriculaService matriculaService)
    {
        _matriculaService = matriculaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMatriculas()
    {
        var matriculas = await _matriculaService.ObterMatriculasAsync();
        return Ok(matriculas);
    }

    /// <summary>
    /// Demonstrando tratamento de exceções de negócio vindas do Service.
    /// A Controller permanece limpa e legível.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> PostMatricula([FromBody] Matricula matricula)
    {
        try
        {
            // Toda a lógica de verificar se o aluno existe ocorre lá no Service.
            // A Controller apenas delega a responsabilidade.
            await _matriculaService.MatricularAlunoAsync(matricula);
            
            return CreatedAtAction(nameof(GetMatriculas), new { id = matricula.MatriculaId }, matricula);
        }
        catch (Exception ex)
        {
            // Se o Service lançar erro (ex: Aluno não encontrado), capturamos aqui.
            return BadRequest(new { erro = ex.Message });
        }
    }
}
