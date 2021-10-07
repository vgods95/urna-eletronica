using ProjetoUrna.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoUrna.Interfaces
{
    public interface ICandidateRepositorio : IRepositorioGenerico<Candidate>
    {
        List<Candidate> PesquisarPorNome(string descricao);
        Candidate PesquisarPorLegenda(int legenda);
        new Task<List<Candidate>> ListarTodos();
    }
}
