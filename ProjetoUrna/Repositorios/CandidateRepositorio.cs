using ProjetoUrna.Interfaces;
using ProjetoUrna.Models;

namespace ProjetoUrna.Repositorios
{
    public class CandidateRepositorio : RepositorioGenerico<Candidate>, ICandidateRepositorio
    {
        public CandidateRepositorio(Context context) : base(context)
        {
        }
    }
}
