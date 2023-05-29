using Microsoft.EntityFrameworkCore;
using Nydus2._0.Models;

namespace Nydus2._0.Db.Repositories
{
    public class HistoricoCargoRepository
    {
        private readonly AppDbContext _dbContext;

        public HistoricoCargoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HistoricoCargo>> ObterHistoricoCargosPorColaborador(int colaboradorId)
        {
            return await _dbContext.HistoricoCargos
                .Where(hc => hc.ColaboradorId == colaboradorId)
                .ToListAsync();
        }

        public async Task AdicionarHistoricoCargo(HistoricoCargo historicoCargo)
        {
            await _dbContext.HistoricoCargos.AddAsync(historicoCargo);
            await _dbContext.SaveChangesAsync();
        }

        // Outros métodos personalizados, se necessário
    }

}
