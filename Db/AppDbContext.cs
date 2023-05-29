using Microsoft.EntityFrameworkCore;
using Nydus2._0.Models;


namespace Nydus2._0.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Empresa> Empresas { get; set; }    
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<HistoricoCargo> HistoricoCargos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais para suas entidades, se necessário
        }
    }
}
