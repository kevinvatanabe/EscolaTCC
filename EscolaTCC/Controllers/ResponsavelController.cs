using EscolaTCC.Models;
using EscolaTCC.Models.DAL;
using Microsoft.AspNetCore.Mvc;

namespace EscolaTCC.Controllers
{
    public class ResponsavelController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: Responsável/Cadastro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Responsavel resp)
        {
            try
            {
                ResponsavelDal respDal = new ResponsavelDal();
                //Armazenando código de Autorização
                resp.Cd_Autorizacao = 2;

                string retornoCadastro = respDal.CadastroResponsavel(resp);

                if (retornoCadastro == "Erro1")
                {
                    //CPF já cadastrado
                    ViewData["ResultadoResponsavel"] = 1;
                    return View();
                }
                else if (retornoCadastro == "Erro2")
                {
                    // E-mail já cadastrado
                    ViewData["ResultadoResponsavel"] = 2;
                    return View();
                }
                else if (retornoCadastro == "Erro3")
                {
                    // CEP não cadastrado
                    ViewData["ResultadoResponsavel"] = 3;
                    return View();
                }
                else
                {
                    // CEP não cadastrado
                    ViewData["ResultadoResponsavel"] = 4;
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        public IActionResult Consulta()
        {
            ResponsavelDal funcDal = new ResponsavelDal();

            return View(funcDal.SelectAllResponsaveis());
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            ResponsavelDal funcDal = new ResponsavelDal();

            return View(funcDal.SelectOneResponsavel(id));
        }

        [HttpPost]
        public IActionResult Editar(Responsavel resp)
        {
            try
            {
                ResponsavelDal funcDal = new ResponsavelDal();
                string retornoAlteracao = funcDal.AlterResponsavel(resp);

                if (retornoAlteracao == "Sim")
                {
                    //Alteração bem sucedida
                    TempData["ResultadoAlterResponsavel"] = 1;
                    return View();
                }
                else if (retornoAlteracao != "Sim")
                {
                    //Erro no CPF repetido ou e-mail da conta repetido
                    TempData["ResultadoAlterResponsavel"] = 2;
                    return View();
                }
                else { }

            }
            catch
            {
                TempData["ResultadoAlterResponsavel"] = 2;
                return View();
            }
            
            return View();
        }

        public IActionResult Excluir(int id, int idLogin)
        {
            try
            {
                ResponsavelDal respDal = new ResponsavelDal();

                respDal.DeleteResponsavel(id, idLogin);

                TempData["ExclusaoResponsavel"] = 1;
                
                return RedirectToAction(nameof(Consulta));
            }
            catch
            {
                TempData["ExclusaoResponsavel"] = 2;

                return RedirectToAction(nameof(Consulta));
            }

        }

        public IActionResult Detalhes(int id)
        {
            ResponsavelDal funcDal = new ResponsavelDal();

            return View(funcDal.SelectOneResponsavel(id));
        }
    }
}