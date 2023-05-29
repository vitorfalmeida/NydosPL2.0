using Microsoft.AspNetCore.Mvc;
using Nydus2._0.Models;
using Nydus2._0.Db.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Nydus2._0.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : Controller
    {
        private readonly EmpresaRepository _empresaRepository;

        public EmpresaController(EmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        [HttpGet("empresas")]
        public async Task<IActionResult> GetEmpresas()
        {
            var empresas = await _empresaRepository.ObterTodasEmpresas();
            return Ok(empresas);
        }

        [HttpGet("empresas/{id}")]
        public async Task<IActionResult> GetEmpresa(int id)
        {
            var empresa = await _empresaRepository.ObterEmpresaPorId(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return Ok(empresa);
        }

        [HttpPost("empresas")]
        public async Task<IActionResult> CreateEmpresa(Empresa empresa)
        {
            await _empresaRepository.AdicionarEmpresa(empresa);
            return CreatedAtAction(nameof(GetEmpresa), new { id = empresa.Id }, empresa);
        }

        [HttpPut("empresas/{id}")]
        public async Task<IActionResult> UpdateEmpresa(int id, Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return BadRequest();
            }

            var existingEmpresa = await _empresaRepository.ObterEmpresaPorId(id);
            if (existingEmpresa == null)
            {
                return NotFound();
            }

            await _empresaRepository.AtualizarEmpresa(empresa);

            return NoContent();
        }

        [HttpDelete("empresas/{id}")]
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            var empresa = await _empresaRepository.ObterEmpresaPorId(id);
            if (empresa == null)
            {
                return NotFound();
            }

            await _empresaRepository.ExcluirEmpresa(empresa);

            return NoContent();
        }

        public IActionResult Index()
        {
            return View("EmpresaView");
        }
    }

}
