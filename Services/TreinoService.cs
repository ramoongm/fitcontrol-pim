using FitControl_API.Models;
using FitControl_API.Repositories;

namespace FitControl_API.Services;

public interface ITreinoService
{
    Task CriarFichaTreinoAsync(Treino treino);
    Task<IEnumerable<Treino>> ObterTreinosAsync();
}

// Regras de negócio relacionadas às fichas de treino.
public class TreinoService : ITreinoService
{
    private readonly ITreinoRepository _treinoRepository;
    private readonly IMatriculaService _matriculaService;

    public TreinoService(ITreinoRepository treinoRepository, IMatriculaService matriculaService)
    {
        _treinoRepository = treinoRepository;
        _matriculaService = matriculaService;
    }

    // Regra de Negócio: Um professor só pode criar uma ficha de treino se o aluno estiver matriculado.
    // E ao criar, inativamos as anteriores para manter o histórico, mas com apenas uma ficha ativa.
    // (Lógica simplificada para demonstração).
    public async Task CriarFichaTreinoAsync(Treino treino)
    {
        bool possuiMatricula = await _matriculaService.AlunoPossuiMatriculaAtivaAsync(treino.AlunoId);
        
        if (!possuiMatricula)
        {
            throw new Exception("Não é possível criar ficha: Aluno não possui matrícula ativa.");
        }

        treino.DataCriacao = DateTime.Now;
        treino.Ativo = true;

        await _treinoRepository.CadastrarAsync(treino);
    }

    public async Task<IEnumerable<Treino>> ObterTreinosAsync()
    {
        return await _treinoRepository.ObterTodosAsync();
    }
}
