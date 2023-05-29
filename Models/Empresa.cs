using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nydus2._0.Models
{
    public class Empresa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$", ErrorMessage = "O CNPJ deve estar no formato 00.000.000/0000-00.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "A Razão Social é obrigatória.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O Nome Fantasia é obrigatório.")]
        public string NomeFantasia { get; set; }

        // Propriedade para retornar uma lista de empresas
        public static List<Empresa> GetEmpresas()
        {
            // Aqui você pode implementar a lógica para obter a lista de empresas do banco de dados ou de outra fonte de dados
            // Neste exemplo, retornaremos uma lista fictícia de empresas

            var empresas = new List<Empresa>
            {
                new Empresa { Id = 1, CNPJ = "00.000.000/0000-00", RazaoSocial = "Empresa 1", NomeFantasia = "Empresa 1" },
                new Empresa { Id = 2, CNPJ = "11.111.111/1111-11", RazaoSocial = "Empresa 2", NomeFantasia = "Empresa 2" },
                new Empresa { Id = 3, CNPJ = "22.222.222/2222-22", RazaoSocial = "Empresa 3", NomeFantasia = "Empresa 3" }
            };

            return empresas;
        }
    }
}
