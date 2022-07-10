using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Models
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {

        }
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(250, ErrorMessage = "M�ximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "M�nimo {0} caracteres")]
        public string? Nome { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999")]
        [Required(ErrorMessage = "Preencha um valor")]
        public decimal Valor { get; set; }

        [DisplayName("Est� Disponivel ?")]
        public bool Disponivel { get; set; }
        [DisplayName("Cliente")]
        public int ClienteId { get; set; }

        public virtual ClienteViewModel? Cliente { get; set; }
    }
}