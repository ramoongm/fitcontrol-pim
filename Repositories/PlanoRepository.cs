using Microsoft.EntityFrameworkCore;
using FitControl_API.Models;
using FitControl_API.Data;

namespace FitControl_API.Repositories;

public class PlanoRepository : IPlanoRepository
{
    private readonly FitControlContext _context;

    public PlanoRepository(FitControlContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Plano>> ObterTodosAsync()
    {
        return await _context.Planos.ToListAsync();
    }

    public async Task<Plano?> ObterPorIdAsync(int id)
    {
        return await _context.Planos.FindAsync(id);
    }

    public async Task CadastrarAsync(Plano plano)
    {
        _context.Planos.Add(plano);
        await _context.SaveChangesAsync();
    }
}
