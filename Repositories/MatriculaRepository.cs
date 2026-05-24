using Microsoft.EntityFrameworkCore;
using FitControl_API.Models;
using FitControl_API.Data;

namespace FitControl_API.Repositories;

// Repositório para gerenciar acesso a dados das matrículas.
// Mantém as lógicas de CRUD isoladas, garantindo que o Entity Framework
// não vaze para outras camadas da aplicação.
public class MatriculaRepository : IMatriculaRepository
{
    private readonly FitControlContext _context;

    public MatriculaRepository(FitControlContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Matricula>> ObterTodasAsync()
    {
        return await _context.Matriculas
            .Include(m => m.Aluno)
            .Include(m => m.Plano)
            .ToListAsync();
    }

    public async Task<Matricula?> ObterPorIdAsync(int id)
    {
        return await _context.Matriculas
            .Include(m => m.Aluno)
            .Include(m => m.Plano)
            .FirstOrDefaultAsync(m => m.MatriculaId == id);
    }
    
    public async Task<IEnumerable<Matricula>> ObterPorAlunoIdAsync(int alunoId)
    {
        return await _context.Matriculas
            .Include(m => m.Plano)
            .Where(m => m.AlunoId == alunoId)
            .ToListAsync();
    }

    public async Task CadastrarAsync(Matricula matricula)
    {
        _context.Matriculas.Add(matricula);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Matricula matricula)
    {
        _context.Matriculas.Update(matricula);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(int id)
    {
        var matricula = await _context.Matriculas.FindAsync(id);
        if (matricula != null)
        {
            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();
        }
    }
}
