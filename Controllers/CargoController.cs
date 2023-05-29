using Microsoft.AspNetCore.Mvc;
using Nydus2._0.Models;
using Nydus2._0.Db.Repositories;
using System.Threading.Tasks;

namespace Nydus2._0.Controllers
{
    public class CargoController : Controller
    {
        private readonly CargoRepository _cargoRepository;

        public CargoController(CargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var cargos = await _cargoRepository.ObterTodosCargos();
            return View(cargos);
        }

        [HttpGet]
        public async Task<IActionResult> GetCargos()
        {
            var cargos = await _cargoRepository.ObterTodosCargos();
            return Ok(cargos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargo(int id)
        {
            var cargo = await _cargoRepository.ObterCargoPorId(id);
            if (cargo == null)
            {
                return NotFound();
            }
            return Ok(cargo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargo(Cargo cargo)
        {
            await _cargoRepository.AdicionarCargo(cargo);
            return CreatedAtAction(nameof(GetCargo), new { id = cargo.Id }, cargo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCargo(int id, Cargo cargo)
        {
            if (id != cargo.Id)
            {
                return BadRequest();
            }

            var existingCargo = await _cargoRepository.ObterCargoPorId(id);
            if (existingCargo == null)
            {
                return NotFound();
            }

            existingCargo.Nome = cargo.Nome; // Atualize os campos necessários do cargo existente
            existingCargo.DescricaoAtividades = cargo.DescricaoAtividades;

            await _cargoRepository.AtualizarCargo(existingCargo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            var cargo = await _cargoRepository.ObterCargoPorId(id);
            if (cargo == null)
            {
                return NotFound();
            }

            await _cargoRepository.ExcluirCargo(cargo);

            return NoContent();
        }
    }
}
