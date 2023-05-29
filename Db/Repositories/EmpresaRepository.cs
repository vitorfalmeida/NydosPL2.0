using Microsoft.EntityFrameworkCore;
using Nydus2._0.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nydus2._0.Db.Repositories
{
    public class EmpresaRepository
    {
        private readonly AppDbContext _dbContext;

        public EmpresaRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Empresa>> ObterTodasEmpresas()
        {
            return await _dbContext.Empresas.ToListAsync();
        }

        public async Task AdicionarEmpresa(Empresa empresa)
        {
            _dbContext.Empresas.Add(empresa);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Empresa> ObterEmpresaPorId(int id)
        {
            return await _dbContext.Empresas.FindAsync(id);
        }

        public async Task AtualizarEmpresa(Empresa empresa)
        {
            _dbContext.Empresas.Update(empresa);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ExcluirEmpresa(Empresa empresa)
        {
            _dbContext.Empresas.Remove(empresa);
            await _dbContext.SaveChangesAsync();
        }
    }
}
