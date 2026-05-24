using Microsoft.EntityFrameworkCore;
using FitControl_API.Models;
using FitControl_API.Data;

namespace FitControl_API.Repositories;

/// <summary>
/// Repositório de Presenças.
/// Demonstra a persistência de um evento transacional (registro de catraca).
/// </summary>
public class PresencaRepository : IPresencaRepository
{
    private readonly FitControlContext _context;

    public PresencaRepository(FitControlContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Presenca>> ObterTodasAsync()
    {
        return await _context.Presencas.Include(p => p.Aluno).ToListAsync();
    }

    public async Task<Presenca?> ObterPorIdAsync(int id)
    {
        return await _context.Presencas.Include(p => p.Aluno)
                                       .FirstOrDefaultAsync(p => p.PresencaId == id);
    }
    
    public async Task<IEnumerable<Presenca>> ObterPorAlunoIdAsync(int alunoId)
    {
        return await _context.Presencas
            .Where(p => p.AlunoId == alunoId)
            .OrderByDescending(p => p.Data)
            .ToListAsync();
    }

    public async Task RegistrarAsync(Presenca presenca)
    {
        _context.Presencas.Add(presenca);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(int id)
    {
        var presenca = await _context.Presencas.FindAsync(id);
        if (presenca != null)
        {
            _context.Presencas.Remove(presenca);
            await _context.SaveChangesAsync();
        }
    }
}
