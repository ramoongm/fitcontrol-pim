using System;

namespace FitControl_API.Models;

/// <summary>
/// Classe responsável por manter o registro de catraca/frequência do aluno.
/// Simples, mas fundamental para regras de negócio (ex: bloquear aluno inadimplente).
/// </summary>
public class Presenca
{
    public int PresencaId { get; set; }

    // Relacionamento com o aluno que compareceu
    public int AlunoId { get; set; }
    public Aluno? Aluno { get; set; }

    // Data e Hora exata da entrada
    public DateTime Data { get; set; }

    // Status da presença. 
    public string Status { get; set; } = "Presente"; 
}
