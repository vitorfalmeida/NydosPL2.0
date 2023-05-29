using Microsoft.EntityFrameworkCore;
using Nydus2._0.Models;

namespace Nydus2._0.Db.Repositories
{
    public class CargoRepository
    {
        private readonly AppDbContext _dbContext;

        public CargoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cargo>> ObterTodosCargos()
        {
            return await _dbContext.Cargos.ToListAsync();
        }

        public async Task AdicionarCargo(Cargo cargo)
        {
            await _dbContext.Cargos.AddAsync(cargo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Cargo> ObterCargoPorId(int id)
        {
            return await _dbContext.Cargos.FindAsync(id);
        }

        public async Task AtualizarCargo(Cargo cargo)
        {
            _dbContext.Cargos.Update(cargo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ExcluirCargo(Cargo cargo)
        {
            _dbContext.Cargos.Remove(cargo);
            await _dbContext.SaveChangesAsync();
        }

        // Outros métodos personalizados, se necessário
    }
}
