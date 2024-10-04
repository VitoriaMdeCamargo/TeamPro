using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TeamPro.Models
{
    [Table("TeamPro_Tb_Estadios_552344")]
    public class Estadio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstadioId { get; set; }

        [Required(ErrorMessage = "O nome do estádio é obrigatório.")]
        public string Nome { get; set; }

        public string Localizacao { get; set; }

        public int Capacidade { get; set; }

        [Range(1800, 2100, ErrorMessage = "Por favor, insira um ano válido.")]
        public int AnoConstrucao { get; set; }

        // 1..1: Relacionamento entre Estadio e Equipe
        [ForeignKey("Equipe")]
        public int EquipeId { get; set; }
        public Equipe? Equipe { get; set; }
    }
}
