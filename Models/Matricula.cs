using System;

namespace FitControl_API.Models;

// A classe Matricula faz a ligação entre um Aluno e o Plano que ele contratou.
// Demonstra o conceito de relacionamento entre classes e estado da entidade.
public class Matricula
{
    public int MatriculaId { get; set; }

    // Chave estrangeira para Aluno
    public int AlunoId { get; set; }
    public Aluno? Aluno { get; set; }

    // Chave estrangeira para Plano (mensal, trimestral, etc)
    public int PlanoId { get; set; }
    public Plano? Plano { get; set; }

    // Período de vigência da matrícula
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }

    // Estado da matrícula. 
    // Em projetos reais mais complexos, isso poderia ser um Enum (Ativa, Cancelada, Expirada).
    public string Status { get; set; } = "Ativa"; 
}
