using Microsoft.EntityFrameworkCore;
using FitControl_API.Models;
using FitControl_API.Data;

namespace FitControl_API.Repositories;

/// <summary>
/// Implementação concreta do repositório de Alunos.
/// Aqui reside o código acoplado ao Entity Framework Core, responsável por ir ao banco de dados.
/// A camada de Negócios (Service) nunca deve saber da existência do Entity Framework.
/// </summary>
public class AlunoRepository : IAlunoRepository
{
    private readonly FitControlContext _context;

    // Injeção de Dependência do contexto do banco de dados
    public AlunoRepository(FitControlContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Aluno>> ObterTodosAsync()
    {
        // Include carrega a tabela relacionada "Usuario" num JOIN (Eager Loading)
        return await _context.Alunos.Include(a => a.Usuario).ToListAsync();
    }

    public async Task<Aluno?> ObterPorIdAsync(int id)
    {
        return await _context.Alunos.Include(a => a.Usuario)
                                    .FirstOrDefaultAsync(a => a.AlunoId == id);
    }

    public async Task CadastrarAsync(Aluno aluno)
    {
        _context.Alunos.Add(aluno);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Aluno aluno)
    {
        _context.Alunos.Update(aluno);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(int id)
    {
        var aluno = await _context.Alunos.FindAsync(id);
        if (aluno != null)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }
    }
}
