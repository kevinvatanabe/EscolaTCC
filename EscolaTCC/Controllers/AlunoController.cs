using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscolaTCC.Models;
using EscolaTCC.Models.DAL;
using Microsoft.AspNetCore.Mvc;

namespace EscolaTCC.Controllers
{
    public class AlunoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}