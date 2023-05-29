namespace Nydus2._0.Models
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Matricula { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public DateTime? DataDemissao { get; set; } // Opcional (pode ser nulo)
        public List<HistoricoCargo> HistoricoCargos { get; set; }
    }

}
