namespace FitControl_API.Models;

public class Plano
{
    public int PlanoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int DuracaoMeses { get; set; }
    public decimal Valor { get; set; }
    public bool Ativo { get; set; } = true;
}
