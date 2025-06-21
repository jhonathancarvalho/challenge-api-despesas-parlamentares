using DespesasParlamentares.API.Implementation.Interface;
using DespesasParlamentares.API.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace DespesasParlamentares.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DespesasController : ControllerBase
    {
        private readonly IDespesasServices _despesasServices;

        public DespesasController(IDespesasServices despesasServices)
        {
            _despesasServices = despesasServices;
        }

        [HttpGet("estados/{unidadeFederativa}")]
        public async Task<IActionResult> ObterDespesasPorEstado(string unidadeFederativa)
        {
            var despesas = await _despesasServices.ObterDespesasPorEstadoAsync(unidadeFederativa);

            if (despesas == null)
                return NotFound(new Response<object>(false, 404, null, $"Nenhuma despesa encontrada para o estado: {unidadeFederativa}"));

            return Ok(new Response<object>(true, 200, despesas));
        }

        [HttpGet("deputados/{deputadoId}")]
        public async Task<IActionResult> ObterDespesasPorDeputado(Guid deputadoId)
        {
            var despesas = await _despesasServices.ObterDespesasPorDeputadoAsync(deputadoId);

            if (despesas == null || !despesas.Any())
                return NotFound(new Response<object>(false, 404, null, $"Nenhuma despesa encontrada para o deputado com ID: {deputadoId}"));

            return Ok(new Response<object>(true, 200, despesas));
        }
    }
}