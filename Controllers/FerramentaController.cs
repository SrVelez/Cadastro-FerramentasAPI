using Cadastro_de_Ferramentas.Handlers.Contracts;
using Cadastro_de_Ferramentas.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro_de_Ferramentas.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class FerramentaController : ControllerBase
    {
        private readonly IFerramentaHandler _ferramentaHandler;

        public FerramentaController(IFerramentaHandler ferramentaHandler)
        {
            _ferramentaHandler = ferramentaHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            try
            {
                var ferramentas = await _ferramentaHandler.GetAllFerramentasAsync();
                if (ferramentas == null)
                {
                    return NoContent();
                }

                return Ok(ferramentas);
            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar recuperar os ferramentas. " + err.Message);
            }

        }

        [HttpGet("ferramenta/{id}")]
        public async Task<IActionResult> GetProdutoById(int id)
        {
            try
            {

                var ferramenta = await _ferramentaHandler.GetFerramentaByIdAsync(id);

                if (ferramenta == null)
                {
                    return NoContent();
                }

                return Ok(ferramenta);

            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar recuperar o ferramenta. " + err.Message);
            }

        }

        [HttpDelete("ferramenta/{id}")]
        public async Task<IActionResult> RemoveProdutoAsync(int id)
        {
            try
            {
                var ferramenta = await _ferramentaHandler.RemoveFerramentaAsync(id);
                if (ferramenta == false)
                {
                    return BadRequest();
                }

                return Ok(ferramenta);
            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar excluir o ferramenta. " + err.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddFerramentaAsync(Ferramenta ferramentaModel)
        {
            try
            {
                var ferramenta = await _ferramentaHandler.AddFerramentaAsync(ferramentaModel);
                if (ferramenta == null)
                {
                    return BadRequest();
                }

                return Ok(ferramenta);

            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tenta adicionar o ferramenta. " + err.Message);
            }
        }

        [HttpPut("ferramenta/{id}")]
        public async Task<IActionResult> UpdateFerramentaAsync(int id, Ferramenta ferramentaModel)
        {
            try
            {
                var ferramenta = await _ferramentaHandler.UpdateFerramentaAsync(id, ferramentaModel);

                if (ferramenta == null)
                {
                    return BadRequest();
                }

                return Ok(ferramenta);


            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao alterar o ferramenta. " + err.Message);
            }

        }
    }
}
