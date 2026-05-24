using System;

namespace FitControl_API.Models;

/// <summary>
/// Representa a ficha de treino de um aluno, elaborada por um professor.
/// Demonstra um relacionamento mais complexo envolvendo três entidades indiretamente.
/// </summary>
public class Treino
{
    public int TreinoId { get; set; }

    // Aluno ao qual a ficha pertence
    public int AlunoId { get; set; }
    public Aluno? Aluno { get; set; }

    // Professor responsável por montar a ficha
    public int ProfessorId { get; set; }
    public Professor? Professor { get; set; }

    // Pode conter um JSON ou texto formatado com os exercícios, séries e repetições
    public string Descricao { get; set; } = string.Empty;
    
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    
    // Define se esta é a ficha de treino atual do aluno
    public bool Ativo { get; set; } = true;
}
