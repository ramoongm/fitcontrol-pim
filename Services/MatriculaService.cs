using FitControl_API.Models;
using FitControl_API.Repositories;

namespace FitControl_API.Services;

public interface IMatriculaService
{
    Task MatricularAlunoAsync(Matricula matricula);
    Task<IEnumerable<Matricula>> ObterMatriculasAsync();
    Task<bool> AlunoPossuiMatriculaAtivaAsync(int alunoId);
}

/// <summary>
/// Concentra as regras de negócio de Matrícula.
/// Evita que a Controller fique sobrecarregada ("Fat Controller"),
/// aplicando o princípio de Responsabilidade Única (S do SOLID).
/// </summary>
public class MatriculaService : IMatriculaService
{
    private readonly IMatriculaRepository _matriculaRepository;
    private readonly IAlunoRepository _alunoRepository;

    // Construtor com injeção de múltiplas dependências
    public MatriculaService(IMatriculaRepository matriculaRepository, IAlunoRepository alunoRepository)
    {
        _matriculaRepository = matriculaRepository;
        _alunoRepository = alunoRepository;
    }

    /// <summary>
    /// Exemplo forte de regra de negócio:
    /// - Verifica se o aluno existe antes de matricular.
    /// - Atribui o status e a data de início automaticamente.
    /// </summary>
    public async Task MatricularAlunoAsync(Matricula matricula)
    {
        var aluno = await _alunoRepository.ObterPorIdAsync(matricula.AlunoId);
        if (aluno == null)
            throw new Exception("Aluno não encontrado para realizar a matrícula.");

        matricula.DataInicio = DateTime.Now;
        matricula.Status = "Ativa";

        await _matriculaRepository.CadastrarAsync(matricula);
    }

    public async Task<IEnumerable<Matricula>> ObterMatriculasAsync()
    {
        return await _matriculaRepository.ObterTodasAsync();
    }

    /// <summary>
    /// Regra para validar se o aluno pode treinar ou receber ficha.
    /// </summary>
    public async Task<bool> AlunoPossuiMatriculaAtivaAsync(int alunoId)
    {
        var matriculas = await _matriculaRepository.ObterPorAlunoIdAsync(alunoId);
        return matriculas.Any(m => m.Status == "Ativa");
    }
}
