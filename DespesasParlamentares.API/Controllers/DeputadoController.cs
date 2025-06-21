using DespesasParlamentares.API.Implementation.Interface;
using DespesasParlamentares.API.Implementation.Services;
using DespesasParlamentares.API.Models.Common;
using DespesasParlamentares.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DespesasParlamentares.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeputadoController : ControllerBase
    {
        private readonly IDeputadoServices _deputadoServices;

        public DeputadoController(IDeputadoServices deputadoServices)
        {
            _deputadoServices = deputadoServices;
        }

        [HttpGet("estados/{unidadeFederativa}/deputados")]
        public async Task<IActionResult> ListarDeputadosPorEstado(string unidadeFederativa)
        {
            var deputados = await _deputadoServices.ListarDeputadosPorEstadoAsync(unidadeFederativa);
            return Ok(new Response<object>(true, 200, deputados));
        }

        [HttpGet("estados/{unidadeFederativa}/deputados/{deputadoId}")]
        public async Task<IActionResult> ObterDeputadoComDespesas(string unidadeFederativa, Guid deputadoId)
        {
            var deputado = await _deputadoServices.ObterDeputadoComDespesasAsync(unidadeFederativa, deputadoId);

            if (deputado is null)
                return NotFound(new Response<object>(false, 404, null, $"Deputado com ID {deputadoId} não encontrado no estado {unidadeFederativa}."));

            return Ok(new Response<object>(true, 200, deputado));
        }
    }
}