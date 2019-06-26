using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscolaTCC.Models.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscolaTCC.Controllers
{
    public class TurmaProfessorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string email;
            email = Convert.ToString(HttpContext.Session.GetString("Email"));

            TurmaProfessorDal turmaProfDal = new TurmaProfessorDal();

            string cpf = Convert.ToString(turmaProfDal.SelecionaProfessorCpf(email));

            HttpContext.Session.SetString("Cpf", cpf);

            Int64 cpf2 = Convert.ToInt64(HttpContext.Session.GetString("Cpf"));

            return View(turmaProfDal.SelectTurmaProfessor(cpf2));
        }
    }
}