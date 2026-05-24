using Microsoft.AspNetCore.Mvc;
using FitControl_API.Models;
using FitControl_API.Services;

namespace FitControl_API.Controllers;

// A camada de Controller (Controlador) é responsável por expor os endpoints da API.
// Ela recebe as requisições HTTP (GET, POST, PUT, DELETE), repassa os dados para a camada 
// de Serviço (Service) e retorna as respostas HTTP.
// IMPORTANTE: Um Controller NUNCA deve conter regras de negócio e NÃO DEVE acessar o banco de dados.
[ApiController] // Indica que a classe é uma API e habilita validação automática de Model
[Route("api/[controller]")] // Define a rota base, ex: api/alunos
public class AlunosController : ControllerBase
{
    private readonly IAlunoService _alunoService;

    // A Injeção de Dependência garante que a Controller não precise instanciar o Service.
    public AlunosController(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }

    // Endpoint para listar todos os alunos (Read).
    // Rota: GET api/alunos
    [HttpGet]
    public async Task<IActionResult> GetAlunos()
    {
        var alunos = await _alunoService.ObterAlunosAsync();
        return Ok(alunos); // Retorna 200 OK com os dados em JSON
    }

    // Endpoint para cadastrar um novo aluno (Create).
    // Rota: POST api/alunos
    [HttpPost]
    public async Task<IActionResult> PostAluno([FromBody] Aluno aluno)
    {
        try
        {
            await _alunoService.CadastrarAlunoAsync(aluno);
            
            // Retorna 201 Created, indicando que o recurso foi criado com sucesso.
            return CreatedAtAction(nameof(GetAlunos), new { id = aluno.AlunoId }, aluno);
        }
        catch (Exception ex)
        {
            // Em caso de falha de validação ou erro de negócio, retorna 400 Bad Request.
            return BadRequest(new { mensagem = ex.Message });
        }
    }
}
