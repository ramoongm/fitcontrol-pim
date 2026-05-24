using FitControl_API.Models;

namespace FitControl_API.Repositories;

public interface ITreinoRepository
{
    Task<IEnumerable<Treino>> ObterTodosAsync();
    Task<Treino?> ObterPorIdAsync(int id);
    Task<IEnumerable<Treino>> ObterPorAlunoIdAsync(int alunoId);
    Task CadastrarAsync(Treino treino);
    Task AtualizarAsync(Treino treino);
    Task ExcluirAsync(int id);
}
