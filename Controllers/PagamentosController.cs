using Microsoft.AspNetCore.Mvc;
using FitControl_API.Models;
using FitControl_API.Services;

namespace FitControl_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PagamentosController : ControllerBase
{
    private readonly IPagamentoService _pagamentoService;

    public PagamentosController(IPagamentoService pagamentoService)
    {
        _pagamentoService = pagamentoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPagamentos()
    {
        var pagamentos = await _pagamentoService.ObterPagamentosAsync();
        return Ok(pagamentos);
    }

    [HttpPost]
    public async Task<IActionResult> PostPagamento([FromBody] Pagamento pagamento)
    {
        try
        {
            await _pagamentoService.RegistrarPagamentoAsync(pagamento);
            return CreatedAtAction(nameof(GetPagamentos), new { id = pagamento.PagamentoId }, pagamento);
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }
}
