using Microsoft.EntityFrameworkCore;
using TeamPro.Models;
namespace TeamPro.Persistence
{
    public class TeamProDbContext : DbContext
    {
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Treinador> Treinadores { get; set; }
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<Partida> Partidas { get; set; }

        public TeamProDbContext(DbContextOptions<TeamProDbContext> options) : base(options) 
        { 

        }

    }
}
