using ProjetoUrna.Interfaces;
using ProjetoUrna.Models;
using System;
using System.Linq;

namespace ProjetoUrna.Repositorios
{
    public class VotingRepositorio : RepositorioGenerico<Voting>, IVotingRepositorio
    {
        Context _context;

        public VotingRepositorio(Context context) : base(context)
        {
            _context = context;
        }

        public int RecuperarQtdVotos(int? candidatoId)
        {
            try
            {
                return _context.Voting.Where(x => x.CandidateId == candidatoId).Count();
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }
    }
}
