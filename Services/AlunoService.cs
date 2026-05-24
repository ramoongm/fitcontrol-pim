using FitControl_API.Models;
using FitControl_API.Repositories;

namespace FitControl_API.Services;

/// <summary>
/// A interface IAlunoService define o "contrato" de operações que podem ser feitas com alunos.
/// Isso permite o uso de Injeção de Dependência, essencial para testes e baixo acoplamento.
/// </summary>
public interface IAlunoService
{
    Task CadastrarAlunoAsync(Aluno aluno);
    Task<IEnumerable<Aluno>> ObterAlunosAsync();
}

/// <summary>
/// A camada de Service (Serviço) é responsável por manter as Regras de Negócio.
/// Um Controller não deve acessar o Banco de Dados diretamente; ele chama o Service,
/// e o Service aplica as regras antes de chamar o Repository.
/// </summary>
public class AlunoService : IAlunoService
{
    // A dependência é para a Interface (IAlunoRepository), não para a classe concreta.
    private readonly IAlunoRepository _alunoRepository;

    public AlunoService(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    /// <summary>
    /// Demonstração de regra de negócio: Todo aluno cadastrado recebe a data atual e nasce ativo.
    /// Em um sistema real, aqui poderíamos validar CPF e formatar telefone antes de salvar.
    /// </summary>
    public async Task CadastrarAlunoAsync(Aluno aluno)
    {
        // Regras de negócio da aplicação
        aluno.DataCadastro = DateTime.Now;
        aluno.Ativo = true;

        // Após validar e aplicar regras, delega a persistência ao Repository
        await _alunoRepository.CadastrarAsync(aluno);
    }

    public async Task<IEnumerable<Aluno>> ObterAlunosAsync()
    {
        return await _alunoRepository.ObterTodosAsync();
    }
}
