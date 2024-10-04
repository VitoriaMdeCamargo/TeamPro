using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TeamPro.Models
{
    [Table("TeamPro_Tb_Treinadores_552344")]
    public class Treinador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TreinadorId { get; set; }

        [Required(ErrorMessage = "O nome do treinador é obrigatório.")]
        public string Nome { get; set; }

        [Range(18, 80, ErrorMessage = "Por favor, insira uma idade válida.")]
        public int Idade { get; set; }

        public string Nacionalidade { get; set; }

        [Column(TypeName = "decimal")]
        [Precision(18, 2)]
        public decimal Salario { get; set; }

        // 1..N: Relacionamento entre Treinador e Equipe
        public int EquipeId { get; set; }
        public Equipe? Equipe { get; set; }
    }
}
