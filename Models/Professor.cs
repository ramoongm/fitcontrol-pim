namespace FitControl_API.Models;

public class Professor
{
    public int ProfessorId { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Especialidade { get; set; }
    public string? Telefone { get; set; }
    public bool Ativo { get; set; } = true;
}
