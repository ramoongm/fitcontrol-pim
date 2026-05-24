using System;

namespace FitControl_API.Models;

// A camada de Model (Modelo) representa as entidades de domínio do sistema.
// É onde definimos a estrutura dos dados, essa classe demonstra o conceito de Abstração e Encapsulamento.
public class Aluno
{
    // A chave primária da entidade no banco de dados.
    public int AlunoId { get; set; }

    // Chave estrangeira para relacionamento com a entidade Usuario (Sistema de login, etc)
    public int UsuarioId { get; set; }
    
    // Propriedade de navegação do Entity Framework. Facilita o acesso ao objeto relacionado.
    public Usuario? Usuario { get; set; }

    // Propriedades básicas encapsuladas. 
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string? Telefone { get; set; }
    public DateTime DataNascimento { get; set; }
    
    // Regra de negócio: ao instanciar, a data de cadastro é a data atual.
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    
    // O aluno nasce ativo no sistema. 
    // Este campo é útil para exclusão lógica, em vez de apagar do banco.
    public bool Ativo { get; set; } = true;
}
