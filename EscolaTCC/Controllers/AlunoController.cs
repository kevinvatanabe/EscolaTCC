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

        [HttpGet]
        public IActionResult Consulta()
        {
            AlunoDal alunoDal = new AlunoDal();
            return View(alunoDal.SelectAllAlunos());
        }

        [HttpPost]
        public IActionResult Consulta(int id)
        {
            AlunoDal alunoDal = new AlunoDal();
            return View(alunoDal.SelectOneAluno(id));
        }

        public IActionResult Detalhes(int id)
        {
            AlunoDal alunoDal = new AlunoDal();
            return View(alunoDal.SelectOneAluno(id));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            AlunoDal alunoDal = new AlunoDal();
            return View(alunoDal.SelectOneAluno(id));
        }

        [HttpPost]
        public IActionResult Editar(Aluno aluno)
        {
            try
            {
                AlunoDal alunoDal = new AlunoDal();
                string retornoAlteracao = alunoDal.AlterAluno(aluno);

                if (retornoAlteracao == "Sim")
                {
                    //Alteração bem sucedida
                    TempData["AlterAluno"] = 1;
                    return View();
                }
                else if (retornoAlteracao != "Sim")
                {
                    //Erro no CPF repetido ou e-mail da conta repetido
                    TempData["AlterAluno"] = 2;
                    return View();
                }
                else { }

            }
            catch
            {
                return View();
            }

            return View();
        }

        public IActionResult Excluir()
        {
            try
            {
                AlunoDal alunoDal = new AlunoDal();
                return RedirectToAction(nameof(Consulta));
            }
            catch
            {
                return RedirectToAction(nameof(Consulta));
            }
        }
    }
}