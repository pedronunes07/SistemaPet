using Microsoft.AspNetCore.Mvc;
using SistemaPet.Dominio;
using SistemaPet.Servico;

namespace SistemaPet.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetServico _servico;

        public PetController(IPetServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var pets = _servico.Listar();
                return Ok(pets);
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
                var pet = _servico.BuscarPorId(id);
                if (pet == null)
                    return NotFound(new { mensagem = "Pet não encontrado." });

                return Ok(pet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pet pet)
        {
            try
            {
                _servico.Adicionar(pet);
                return CreatedAtAction(nameof(Get), new { id = pet.Id }, new { mensagem = "Pet cadastrado com sucesso!", pet });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pet pet)
        {
            try
            {
                if (id != pet.Id)
                    return BadRequest(new { mensagem = "ID do pet não corresponde." });

                _servico.Atualizar(pet);
                return Ok(new { mensagem = "Pet atualizado com sucesso!", pet });
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
                return Ok(new { mensagem = "Pet removido com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}

