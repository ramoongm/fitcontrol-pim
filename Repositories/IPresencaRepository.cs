using FitControl_API.Models;

namespace FitControl_API.Repositories;

public interface IPresencaRepository
{
    Task<IEnumerable<Presenca>> ObterTodasAsync();
    Task<Presenca?> ObterPorIdAsync(int id);
    Task<IEnumerable<Presenca>> ObterPorAlunoIdAsync(int alunoId);
    Task RegistrarAsync(Presenca presenca);
    Task ExcluirAsync(int id);
}
