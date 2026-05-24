using FitControl_API.Models;
using FitControl_API.Repositories;

namespace FitControl_API.Services;

public interface IPresencaService
{
    Task RegistrarPresencaAsync(Presenca presenca);
    Task<IEnumerable<Presenca>> ObterPresencasAsync();
}

// Serviço de Presença.
// Junta informações do Aluno, Matrícula e registro de catraca.
public class PresencaService : IPresencaService
{
    private readonly IPresencaRepository _presencaRepository;
    private readonly IMatriculaService _matriculaService;

    public PresencaService(IPresencaRepository presencaRepository, IMatriculaService matriculaService)
    {
        _presencaRepository = presencaRepository;
        _matriculaService = matriculaService;
    }

    // Regra de negócio vital: O aluno só pode registrar presença (entrar na academia)
    // se ele possuir uma matrícula ativa
    public async Task RegistrarPresencaAsync(Presenca presenca)
    {
        bool possuiMatricula = await _matriculaService.AlunoPossuiMatriculaAtivaAsync(presenca.AlunoId);
        
        if (!possuiMatricula)
        {
            // Lançar exceção interrompe o fluxo e garante que dados inválidos não cheguem ao banco.
            throw new Exception("Acesso Negado: Aluno não possui matrícula ativa.");
        }

        presenca.Data = DateTime.Now;
        await _presencaRepository.RegistrarAsync(presenca);
    }

    public async Task<IEnumerable<Presenca>> ObterPresencasAsync()
    {
        return await _presencaRepository.ObterTodasAsync();
    }
}
