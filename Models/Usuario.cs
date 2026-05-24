namespace FitControl_API.Models;

public class Usuario
{
    public int UsuarioId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string TipoUsuario { get; set; } = string.Empty; // Aluno, Professor, Admin
    public bool Ativo { get; set; } = true;
    public DateTime DataCriacao { get; set; } = DateTime.Now;
}
