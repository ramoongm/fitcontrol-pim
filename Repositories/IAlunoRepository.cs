using FitControl_API.Models;

namespace FitControl_API.Repositories;

// Interface do Repositório de Alunos.
// O padrão Repository (Repositório) isola a camada de dados (banco) do resto da aplicação.
// facilitando testes unitários (Mock) e a troca de tecnologia de banco de dados no futuro, se necessário.
public interface IAlunoRepository
{
    // Métodos para o CRUD.
    Task<IEnumerable<Aluno>> ObterTodosAsync();
    Task<Aluno?> ObterPorIdAsync(int id);
    Task CadastrarAsync(Aluno aluno);
    Task AtualizarAsync(Aluno aluno);
    Task ExcluirAsync(int id);
}
