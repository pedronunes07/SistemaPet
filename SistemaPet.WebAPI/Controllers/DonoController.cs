using Microsoft.AspNetCore.Mvc;
using SistemaPet.Dominio;
using SistemaPet.Servico;

namespace SistemaPet.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonoController : ControllerBase
    {
        private readonly IDonoServico _servico;

        public DonoController(IDonoServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var donos = _servico.Listar();
                return Ok(donos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var dono = _servico.BuscarPorId(id);
                if (dono == null)
                    return NotFound(new { mensagem = "Dono não encontrado." });

                return Ok(dono);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Dono dono)
        {
            try
            {
                _servico.Adicionar(dono);
                return CreatedAtAction(nameof(Get), new { id = dono.Id }, new { mensagem = "Dono cadastrado com sucesso!", dono });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Dono dono)
        {
            try
            {
                if (id != dono.Id)
                    return BadRequest(new { mensagem = "ID do dono não corresponde." });

                _servico.Atualizar(dono);
                return Ok(new { mensagem = "Dono atualizado com sucesso!", dono });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _servico.Remover(id);
                return Ok(new { mensagem = "Dono removido com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}

