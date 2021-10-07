using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoUrna.Interfaces;
using ProjetoUrna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUrna.Controllers
{
    public class VotingController : Controller
    {
        private IVotingRepositorio _IVotingRepositorio;

        public VotingController(IVotingRepositorio IVotingRepositorio)
        {
            _IVotingRepositorio = IVotingRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult votes()
        {
            return View();
        }

        //O Id do candidato não é mais um campo obrigatório, portanto se não tiver preenchido contabilizar como um voto branco ou nulo
        [HttpPost]
        public async Task<JsonResult> vote(string candidatoJson)
        {
            Voting voting = new Voting();
            voting.DataVoto = DateTime.Now;

            if (!string.IsNullOrEmpty(candidatoJson))
            {
                Candidate candidate = JsonConvert.DeserializeObject<Candidate>(candidatoJson);
                voting.CandidateId = candidate.Id;
            }

            await _IVotingRepositorio.Inserir(voting);
            return Json("SUCESSO");
        }
    }
}
