using DespesasParlamentares.API.Implementation.Interface;
using DespesasParlamentares.API.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace DespesasParlamentares.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DadosController : ControllerBase
    {
        private readonly IBaseDadosServices _carregarBaseServices;

        public DadosController(IBaseDadosServices carregarBaseServices)
        {
            _carregarBaseServices = carregarBaseServices;
        }

        [HttpPost("dados")]
        public async Task<ActionResult<Response<string>>> DadosParlamentar(IFormFile file, string unidadeFederativa)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new Response<string>(false, 400, null, "O arquivo CSV é obrigatório."));

            if (string.IsNullOrWhiteSpace(unidadeFederativa) || unidadeFederativa.Length != 2)
                return BadRequest(new Response<string>(false, 400, null, "A UF (Unidade Federativa) é obrigatória e deve conter 2 letras."));

            var tempPath = Path.Combine(Path.GetTempPath(), file.FileName);

            try
            {
                using var stream = new FileStream(tempPath, FileMode.Create);
                await file.CopyToAsync(stream);

                await _carregarBaseServices.CarregarBaseDados(tempPath, unidadeFederativa.ToUpper());

                return Ok(new Response<string>(true, 200, "Base de dados carregada com sucesso."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response<string>(false, 500, null, $"Erro ao processar o arquivo: {ex.Message}"));
            }
        }
    }
}