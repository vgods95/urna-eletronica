using ProjetoUrna.Interfaces;
using ProjetoUrna.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoUrna.Repositorios
{
    public class CandidateRepositorio : RepositorioGenerico<Candidate>, ICandidateRepositorio
    {
        private readonly Context _context;

        public CandidateRepositorio(Context context) : base(context)
        {
            _context = context;
        }

        public Candidate PesquisarPorLegenda(int legenda)
        {
            try
            {
                return _context.Candidate.Where(x => x.Legenda == legenda).FirstOrDefault();
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public List<Candidate> PesquisarPorNome(string descricao)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(descricao))
                    return _context.Candidate.OrderBy(x => x.NomeCompleto).ToList<Candidate>();
                else
                    return _context.Candidate.Where(x => x.NomeCompleto.Contains(descricao)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
