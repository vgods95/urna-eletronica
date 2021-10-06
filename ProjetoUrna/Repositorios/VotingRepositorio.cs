using ProjetoUrna.Interfaces;
using ProjetoUrna.Models;

namespace ProjetoUrna.Repositorios
{
    public class VotingRepositorio : RepositorioGenerico<Voting>, IVotingRepositorio
    {
        public VotingRepositorio(Context context) : base(context)
        {
        }
    }
}
