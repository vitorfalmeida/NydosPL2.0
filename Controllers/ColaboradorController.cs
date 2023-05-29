using Microsoft.AspNetCore.Mvc;
using Nydus2._0.Models;
using Nydus2._0.Db.Repositories;


namespace Nydus2._0.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColaboradorController : ControllerBase
    {
        private readonly ColaboradorRepository _colaboradorRepository;

        public ColaboradorController(ColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetColaboradores()
        {
            var colaboradores = await _colaboradorRepository.ObterTodosColaboradores();
            return Ok(colaboradores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColaborador(int id)
        {
            var colaborador = await _colaboradorRepository.ObterColaboradorPorId(id);
            if (colaborador == null)
            {
                return NotFound();
            }
            return Ok(colaborador);
        }

        [HttpPost]
        public async Task<IActionResult> CreateColaborador(Colaborador colaborador)
        {
            await _colaboradorRepository.AdicionarColaborador(colaborador);
            return CreatedAtAction(nameof(GetColaborador), new { id = colaborador.Id }, colaborador);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColaborador(int id, Colaborador colaborador)
        {
            if (id != colaborador.Id)
            {
                return BadRequest();
            }

            var existingColaborador = await _colaboradorRepository.ObterColaboradorPorId(id);
            if (existingColaborador == null)
            {
                return NotFound();
            }

            await _colaboradorRepository.AtualizarColaborador(colaborador);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColaborador(int id)
        {
            var colaborador = await _colaboradorRepository.ObterColaboradorPorId(id);
            if (colaborador == null)
            {
                return NotFound();
            }

            await _colaboradorRepository.ExcluirColaborador(colaborador);

            return NoContent();
        }
    }
}
