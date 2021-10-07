using ProjetoUrna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUrna.ViewModels
{
    public class ApuracaoViewModel
    {
        public string NomeCompleto { get; set; }
        public string NomeVice { get; set; }
        public int QtdVotos { get; set; }
        public double PercentualVotos { get; set; }
    }
}
