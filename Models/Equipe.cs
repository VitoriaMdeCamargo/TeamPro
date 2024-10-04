using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TeamPro.Models
{

    [Table("TeamPro_Tb_Equipes_552344")]
    public class Equipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EquipeId { get; set; }

        [Required(ErrorMessage = "O nome da equipe é obrigatório.")]
        public string Nome { get; set; }

        public string PaisSede { get; set; }

        [Range(1800, 2100, ErrorMessage = "Por favor, insira um ano válido.")]
        public int AnoFundacao { get; set; }

        // 1..1: Relacionamento entre Equipe e Estádio
        public int EstadioId { get; set; }
        public Estadio? Estadio { get; set; }

        // 1..N: Relacionamento entre Equipe e Jogadores
        public ICollection<Jogador>? Jogadores { get; set; }

    }
}
