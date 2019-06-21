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

        [HttpPost]
        public IActionResult Index(Aluno aluno)
        {
            try
            {
                AlunoDal alunoDal = new AlunoDal();

                string retornoCadastro = alunoDal.CadastroAluno(aluno);

                if (retornoCadastro == "Erro1")
                {
                    //CPF já cadastrado
                    ViewData["ResultadoAluno"] = 1;
                    return View();
                }
                else
                {
                    //Sucesso
                    ViewData["ResultadoAluno"] = 2;
                    return View();
                }
            }
            catch
            {
                ViewData["ResultadoAluno"] = 3;
                return View();
            }

        }
    }
}