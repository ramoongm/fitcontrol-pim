using FitControl_API.Models;
using FitControl_API.Repositories;

namespace FitControl_API.Services;

public interface IPagamentoService
{
    Task RegistrarPagamentoAsync(Pagamento pagamento);
    Task<IEnumerable<Pagamento>> ObterPagamentosAsync();
}

// Contém regras de negócio financeiras.
public class PagamentoService : IPagamentoService
{
    private readonly IPagamentoRepository _pagamentoRepository;
    private readonly IMatriculaRepository _matriculaRepository;

    public PagamentoService(IPagamentoRepository pagamentoRepository, IMatriculaRepository matriculaRepository)
    {
        _pagamentoRepository = pagamentoRepository;
        _matriculaRepository = matriculaRepository;
    }

    // Exemplo de regra de negócio: Se o pagamento está sendo registrado agora sem data, 
    // e o valor for maior que zero, consideramos pago hoje, além de validar se a matrícula existe.
    public async Task RegistrarPagamentoAsync(Pagamento pagamento)
    {
        var matricula = await _matriculaRepository.ObterPorIdAsync(pagamento.MatriculaId);
        if (matricula == null)
            throw new Exception("Matrícula não encontrada.");

        if (pagamento.Status == "Pago" && pagamento.DataPagamento == null)
        {
            pagamento.DataPagamento = DateTime.Now;
        }

        await _pagamentoRepository.CadastrarAsync(pagamento);
    }

    public async Task<IEnumerable<Pagamento>> ObterPagamentosAsync()
    {
        return await _pagamentoRepository.ObterTodosAsync();
    }
}
