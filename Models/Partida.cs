using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TeamPro.Models
{
    [Table("TeamPro_Tb_Partidas_552344")]
    public class Partida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartidaId { get; set; }

        [Required(ErrorMessage = "A data e hora da partida são obrigatórias.")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O estádio da partida é obrigatório.")]
        public string Estadio { get; set; }

        // 1..N: Relacionamento entre Partida e Equipe
        public int EquipeId { get; set; }
        public Equipe? Equipe { get; set; }

        // N para N: Relacionamento entre Partida e Jogadores
        public ICollection<Jogador>? Jogadores { get; set; }
    }
}

