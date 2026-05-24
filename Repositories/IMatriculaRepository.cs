using FitControl_API.Models;

namespace FitControl_API.Repositories;

public interface IMatriculaRepository
{
    Task<IEnumerable<Matricula>> ObterTodasAsync();
    Task<Matricula?> ObterPorIdAsync(int id);
    Task<IEnumerable<Matricula>> ObterPorAlunoIdAsync(int alunoId);
    Task CadastrarAsync(Matricula matricula);
    Task AtualizarAsync(Matricula matricula);
    Task ExcluirAsync(int id);
}
