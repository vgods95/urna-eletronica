using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUrna.Controllers
{
    public class VotingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult votes()
        {
            return View();
        }
    }
}
