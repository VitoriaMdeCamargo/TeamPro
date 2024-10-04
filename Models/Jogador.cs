using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TeamPro.Models
{
    [Table("TeamPro_Tb_Jogadores_552344")]
    public class Jogador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JogadorId { get; set; }

        [Required(ErrorMessage = "O nome do jogador é obrigatório.")]
        public string Nome { get; set; }

        public string Posicao { get; set; }

        [Range(16, 50, ErrorMessage = "Por favor, insira uma idade válida.")]
        public int Idade { get; set; }

        public string Nacionalidade { get; set; }

        [Column(TypeName = "decimal")]
        [Precision(18, 2)]
        public decimal Salario { get; set; }

        // 1..N: Relacionamento entre Jogador e Equipe
        public int EquipeId { get; set; }
        public Equipe? Equipe { get; set; }

        // N para N: Relacionamento entre Partida e Jogadores
        public ICollection<Partida>? Partidas { get; set; }
    }
}

