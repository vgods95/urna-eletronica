﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoUrna.Interfaces;
using ProjetoUrna.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoUrna.Controllers
{
    public class CandidateController : Controller
    {
        private ICandidateRepositorio _ICandidateRepositorio;

        public CandidateController(ICandidateRepositorio ICandidateRepositorio)
        {
            _ICandidateRepositorio = ICandidateRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Pesquisar(string descricao)
        {
            List<Candidate> listaCandidatos = _ICandidateRepositorio.PesquisarPorNome(descricao);
            return PartialView("_TabelaPesquisa", listaCandidatos);
        }

        [HttpPost]
        public async Task<JsonResult> candidate(string candidateJson)
        {
            try
            {
                if (!string.IsNullOrEmpty(candidateJson))
                {
                    Candidate candidate = JsonConvert.DeserializeObject<Candidate>(candidateJson);
                    Candidate legendaExistente = _ICandidateRepositorio.PesquisarPorLegenda(candidate.Legenda);
                    
                    if (legendaExistente != null)
                        return Json(string.Concat("Falha ao gravar! Essa legenda já está cadastrada para o candidato ", legendaExistente.NomeCompleto));
                    else
                    {
                        candidate.DataRegistro = DateTime.Now;
                        await _ICandidateRepositorio.Inserir(candidate);
                        return Json("SUCESSO");
                    }
                }

                return Json("Ocorreram erros ao gravar. Contate o suporte!");

            }
            catch (Exception)
            {
                return Json("Ocorreram erros ao gravar. Contate o suporte!");
            }
        }

        [HttpDelete]
        public async Task<JsonResult> candidate(int id)
        {
            if (id != 0)
            {
                await _ICandidateRepositorio.Excluir(id);
                return Json("SUCESSO");
            }

            return Json("Ocorreram erros ao excluir. Contate o suporte!");
        }
    }
}
