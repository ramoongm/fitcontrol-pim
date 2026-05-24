using System;

namespace FitControl_API.Models;

/// <summary>
/// Representa as transações financeiras (Pagamentos) referentes a uma matrícula.
/// Modelos financeiros geralmente requerem tipos específicos como 'decimal' para precisão.
/// </summary>
public class Pagamento
{
    public int PagamentoId { get; set; }

    // Vincula o pagamento diretamente à matrícula do aluno
    public int MatriculaId { get; set; }
    public Matricula? Matricula { get; set; }

    // O tipo decimal é crucial para valores monetários devido à precisão de casas decimais.
    public decimal Valor { get; set; }
    
    // Pode ser nulo se o status for "Pendente"
    public DateTime? DataPagamento { get; set; }
    
    // Mês/Ano ao qual este pagamento se refere (ex: "2023-10")
    public string MesReferencia { get; set; } = string.Empty; 
    
    // Controla se a mensalidade foi paga, está pendente ou atrasada
    public string Status { get; set; } = "Pendente"; 
    
    // Cartão, PIX, Dinheiro...
    public string MetodoPagamento { get; set; } = string.Empty;
}
