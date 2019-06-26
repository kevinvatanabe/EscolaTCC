using EscolaTCC.Models.BLL;
using EscolaTCC.Models.DAL;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EscolaTCC.Controllers
{
    public class TurmaAlunoController : Controller
    {

        public IActionResult Index(int id, string Nome ,string Turno, string Serie)
        {
            TurmaAlunoDal turmaAlunoDal = new TurmaAlunoDal();
            TempData["CodTurma"] = id;
            TempData["NomeTurma"] = Nome;

            return View(turmaAlunoDal.SelectAlunoTurmaProfessorMateria(id));
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(TurmaAluno turmaAluno)
        {
            try
            {
                TurmaAlunoDal turmaAlunoDal = new TurmaAlunoDal();
                string sucesso = turmaAlunoDal.CadastroMateriaProfessor(turmaAluno);
                if (sucesso == "Sim")
                {
                    //Cadastro feito
                    TempData["ResultadoMateria"] = 1;
                    return View();
                }
                else
                {
                    //Erro
                    TempData["ResultadoMateria"] = 2;
                    return View();
                }
              
            }
            catch
            {
                TempData["ResultadoMateria"] = 2;
                return View();
            }
        }
    }
}