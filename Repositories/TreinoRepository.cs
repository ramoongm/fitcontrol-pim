using Microsoft.EntityFrameworkCore;
using FitControl_API.Models;
using FitControl_API.Data;

namespace FitControl_API.Repositories;

/// <summary>
/// Repositório de Fichas de Treino.
/// Gerencia a comunicação com a tabela de Treinos do banco de dados.
/// </summary>
public class TreinoRepository : ITreinoRepository
{
    private readonly FitControlContext _context;

    public TreinoRepository(FitControlContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Treino>> ObterTodosAsync()
    {
        return await _context.Treinos
            .Include(t => t.Aluno)
            .Include(t => t.Professor)
            .ToListAsync();
    }

    public async Task<Treino?> ObterPorIdAsync(int id)
    {
        return await _context.Treinos
            .Include(t => t.Aluno)
            .Include(t => t.Professor)
            .FirstOrDefaultAsync(t => t.TreinoId == id);
    }
    
    public async Task<IEnumerable<Treino>> ObterPorAlunoIdAsync(int alunoId)
    {
        return await _context.Treinos
            .Where(t => t.AlunoId == alunoId && t.Ativo)
            .ToListAsync();
    }

    public async Task CadastrarAsync(Treino treino)
    {
        _context.Treinos.Add(treino);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Treino treino)
    {
        _context.Treinos.Update(treino);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(int id)
    {
        var treino = await _context.Treinos.FindAsync(id);
        if (treino != null)
        {
            _context.Treinos.Remove(treino);
            await _context.SaveChangesAsync();
        }
    }
}
