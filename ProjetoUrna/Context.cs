using Microsoft.EntityFrameworkCore;
using ProjetoUrna.Mapeamentos;
using ProjetoUrna.Models;

namespace ProjetoUrna
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CandidateMap());
            builder.ApplyConfiguration(new VotingMap());
        }

        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Voting> Voting { get; set; }
    }
}
