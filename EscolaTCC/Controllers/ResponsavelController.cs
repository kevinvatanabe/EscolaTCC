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
    }
}