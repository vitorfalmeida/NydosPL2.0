using Microsoft.AspNetCore.Mvc;
using Nydus2._0.Models;
using Nydus2._0.Db.Repositories;
using System.Threading.Tasks;

namespace Nydus2._0.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoricoCargoController : ControllerBase
    {
        private readonly HistoricoCargoRepository _historicoCargoRepository;

        public HistoricoCargoController(HistoricoCargoRepository historicoCargoRepository)
        {
            _historicoCargoRepository = historicoCargoRepository;
        }

        [HttpGet("colaborador/{colaboradorId}")]
        public async Task<IActionResult> GetHistoricoCargosPorColaborador(int colaboradorId)
        {
            var historicoCargos = await _historicoCargoRepository.ObterHistoricoCargosPorColaborador(colaboradorId);
            return Ok(historicoCargos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHistoricoCargo(HistoricoCargo historicoCargo)
        {
            await _historicoCargoRepository.AdicionarHistoricoCargo(historicoCargo);
            return CreatedAtAction(nameof(GetHistoricoCargosPorColaborador), new { colaboradorId = historicoCargo.ColaboradorId }, historicoCargo);
        }

        // Outros métodos, se necessário
    }
}
