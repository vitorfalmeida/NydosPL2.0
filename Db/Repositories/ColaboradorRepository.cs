using Microsoft.EntityFrameworkCore;
using Nydus2._0.Models;

namespace Nydus2._0.Db.Repositories
{
    public class ColaboradorRepository
    {
        private readonly AppDbContext _dbContext;

        public ColaboradorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Colaborador>> ObterTodosColaboradores()
        {
            return await _dbContext.Colaboradores
                .Include(c => c.HistoricoCargos)
                .ToListAsync();
        }

        public async Task AdicionarColaborador(Colaborador colaborador)
        {
            await _dbContext.Colaboradores.AddAsync(colaborador);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Colaborador> ObterColaboradorPorId(int id)
        {
            return await _dbContext.Colaboradores.FindAsync(id);
        }

        public async Task AtualizarColaborador(Colaborador colaborador)
        {
            _dbContext.Colaboradores.Update(colaborador);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ExcluirColaborador(Colaborador colaborador)
        {
            _dbContext.Colaboradores.Remove(colaborador);
            await _dbContext.SaveChangesAsync();
        }

        // Outros métodos personalizados, se necessário
    }
}
