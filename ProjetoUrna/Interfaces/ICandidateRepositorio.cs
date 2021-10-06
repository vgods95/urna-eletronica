using ProjetoUrna.Models;
using System.Collections.Generic;

namespace ProjetoUrna.Interfaces
{
    public interface ICandidateRepositorio : IRepositorioGenerico<Candidate>
    {
        List<Candidate> PesquisarPorNome(string descricao);
        Candidate PesquisarPorLegenda(int legenda);
    }
}
