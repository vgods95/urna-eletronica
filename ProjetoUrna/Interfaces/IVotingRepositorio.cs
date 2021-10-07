using ProjetoUrna.Models;

namespace ProjetoUrna.Interfaces
{
    public interface IVotingRepositorio : IRepositorioGenerico<Voting>
    {
        int RecuperarQtdVotos(int candidatoId);
    }
}
