using FitControl_API.Models;

namespace FitControl_API.Repositories;

public interface IPlanoRepository
{
    Task<IEnumerable<Plano>> ObterTodosAsync();
    Task<Plano?> ObterPorIdAsync(int id);
    Task CadastrarAsync(Plano plano);
}
