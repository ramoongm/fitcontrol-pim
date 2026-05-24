using Microsoft.EntityFrameworkCore;
using FitControl_API.Models;

namespace FitControl_API.Data;

public class FitControlContext : DbContext
{
    public FitControlContext(DbContextOptions<FitControlContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<Aluno> Alunos { get; set; } = null!;
    public DbSet<Professor> Professores { get; set; } = null!;
    public DbSet<Plano> Planos { get; set; } = null!;
    public DbSet<Matricula> Matriculas { get; set; } = null!;
    public DbSet<Pagamento> Pagamentos { get; set; } = null!;
    public DbSet<Presenca> Presencas { get; set; } = null!;
    public DbSet<Treino> Treinos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().ToTable("Usuario");
        modelBuilder.Entity<Aluno>().ToTable("Aluno");
        modelBuilder.Entity<Professor>().ToTable("Professor");
        modelBuilder.Entity<Plano>().ToTable("Plano");
        modelBuilder.Entity<Matricula>().ToTable("Matricula");
        modelBuilder.Entity<Pagamento>().ToTable("Pagamento");
        modelBuilder.Entity<Presenca>().ToTable("Presenca");
        modelBuilder.Entity<Treino>().ToTable("Treino");
        
        // Configuração de unique indexes
        modelBuilder.Entity<Usuario>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<Aluno>().HasIndex(a => a.Cpf).IsUnique();
        
        // Relacionamentos adicionais podem ser configurados aqui
    }
}
