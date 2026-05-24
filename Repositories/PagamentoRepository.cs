using Microsoft.EntityFrameworkCore;
using FitControl_API.Models;
using FitControl_API.Data;

namespace FitControl_API.Repositories;

/// <summary>
/// Repositório de Pagamentos.
/// Responsável pelas operações de CRUD (Create, Read, Update, Delete) de Pagamentos
/// utilizando o Entity Framework Core.
/// </summary>
public class PagamentoRepository : IPagamentoRepository
{
    private readonly FitControlContext _context;

    public PagamentoRepository(FitControlContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pagamento>> ObterTodosAsync()
    {
        return await _context.Pagamentos.Include(p => p.Matricula).ToListAsync();
    }

    public async Task<Pagamento?> ObterPorIdAsync(int id)
    {
        return await _context.Pagamentos.Include(p => p.Matricula)
                                        .FirstOrDefaultAsync(p => p.PagamentoId == id);
    }
    
    public async Task<IEnumerable<Pagamento>> ObterPorMatriculaIdAsync(int matriculaId)
    {
        return await _context.Pagamentos
            .Where(p => p.MatriculaId == matriculaId)
            .ToListAsync();
    }

    public async Task CadastrarAsync(Pagamento pagamento)
    {
        _context.Pagamentos.Add(pagamento);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Pagamento pagamento)
    {
        _context.Pagamentos.Update(pagamento);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(int id)
    {
        var pagamento = await _context.Pagamentos.FindAsync(id);
        if (pagamento != null)
        {
            _context.Pagamentos.Remove(pagamento);
            await _context.SaveChangesAsync();
        }
    }
}
