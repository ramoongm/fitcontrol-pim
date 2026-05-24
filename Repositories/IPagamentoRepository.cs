using FitControl_API.Models;

namespace FitControl_API.Repositories;

public interface IPagamentoRepository
{
    Task<IEnumerable<Pagamento>> ObterTodosAsync();
    Task<Pagamento?> ObterPorIdAsync(int id);
    Task<IEnumerable<Pagamento>> ObterPorMatriculaIdAsync(int matriculaId);
    Task CadastrarAsync(Pagamento pagamento);
    Task AtualizarAsync(Pagamento pagamento);
    Task ExcluirAsync(int id);
}
