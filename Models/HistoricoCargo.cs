namespace Nydus2._0.Models
{
    public class HistoricoCargo
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }
        public DateTime DataInicioVigencia { get; set; }
    }
}
