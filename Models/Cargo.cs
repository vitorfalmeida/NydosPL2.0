using System.ComponentModel.DataAnnotations;

namespace Nydus2._0.Models
{
    public class Cargo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo CBO é obrigatório.")]
        [StringLength(10, ErrorMessage = "O campo CBO deve ter no máximo 10 caracteres.")]
        public string CBO { get; set; }

        [Required(ErrorMessage = "O campo Descrição das Atividades é obrigatório.")]
        [StringLength(500, ErrorMessage = "O campo Descrição das Atividades deve ter no máximo 500 caracteres.")]
        public string DescricaoAtividades { get; set; }
    }
}
