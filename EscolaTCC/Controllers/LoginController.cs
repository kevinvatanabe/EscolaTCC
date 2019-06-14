using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscolaTCC.Models;
using EscolaTCC.Models.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscolaTCC.Controllers
{
    public class LoginController : Controller
    {
        //Instanciando a classe para passar como parâmetro o objeto "login" para o Post de Index => Login.
        Login login = new Login();

        //Quando a página for carregada, HttpGet iniciará o método abaixo.
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    
        //Quando for acionado o "submit" da respectiva View, o HttpPost acionará este método.
        //ValidateAntiForgeryToken serve para evitar "ataques" e recebimento de dados falsos.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Login login, IFormCollection frm, LoginDal loginDal)
        {
            //ModelState.IsValid : eu li que o atributo "asp-for" presente nas tags já direcionava os dados automaticamente para o Model.
            //Porém, isso não funcionou. Logo, tive que injetar manualmente os dados das tags para os atributos do Model.
            if (ModelState.IsValid) 
            {
                login.NmEmail = frm["txtEmail"];
                login.NmSenha = frm["txtSenha"];

                //Verifica se é um Responsável, Professor, Secretária ou Diretor.
                if (frm["Autorizacao"] == "Professor")
                    login.CdAutorizacao = 1;

                else if (frm["Autorizacao"] == "Responsavel")
                    login.CdAutorizacao = 2;

                else if (frm["Autorizacao"] == "Secretaria")
                    login.CdAutorizacao = 3;
                else
                    login.CdAutorizacao = 4;

                //Aqui eu instancio o método da classe para uma variável para poupar processamento.
                //Só necessitarei do retorno do método e não de seu processamento.
                string retornoVerificaLogin = loginDal.VerificaUsuario(login);

                //Se o Banco retornar "Sim", logo eu armazenarei tudo nas Sessions para utilização posterior.
                if (retornoVerificaLogin == "Sim")
                {
                  
                    string SessionEmail = login.NmEmail;
                    string SessionSenha = login.NmSenha;
                    int SessionAutorizacao = login.CdAutorizacao;

                    //Estas sessions deram um trabalho. Primeiro preciso utilizar seus serviços em Startup.cs.
                    //Portanto, todas as configurações como validade e outros estão dentro de Services na classe Startup.cs do projeto.
                    HttpContext.Session.SetString("Email", SessionEmail);
                    HttpContext.Session.SetString("Senha", SessionSenha);
                    HttpContext.Session.SetInt32("Autorizacao", SessionAutorizacao);

                    //Após verificado o Login, posso voltar a minha Pagina Inicial.
                    //O _Layout carregado será definido em _ViewStart.cshtml.
                    return RedirectToAction("Index", "Home");
                }
                else if (retornoVerificaLogin == "Nao")
                {
                    //Talvez essa lógica seja deprimente, porém é um bom desencargo de consciência.
                    //Caso dê algum erro, será carregada a mesma View com o Alert Message
                    ViewData["Resultado"] = 2;
                    return View();
                }
                else
                {
                    //Caso dê algum erro, será carregada a mesma View com o Alert Message. Neste caso o usuário pesquisado não existe.
                    ViewData["Resultado"] = 3;
                    return View();
                }
            }

            //Caso ocorra nada...
            return View();
        }

        //Quando o usuário clicar em Sair na NavBat a View redirecionará para este método
        public IActionResult Logoff()
        {
            //Aqui estou esvaziando as Sessions, estou prenchendo-as com um espaço.
            //Somente na SessionAutorizacao será enviado um zero, pois este zero carregará o _LayoutDeslogado. - _ViewStart.cshtml.
            string SessionEmail = " ";
            string SessionSenha = " ";
            int SessionAutorizacao = 0;

            HttpContext.Session.SetString("Email", SessionEmail);
            HttpContext.Session.SetString("Senha", SessionSenha);
            HttpContext.Session.SetInt32("Autorizacao", SessionAutorizacao);

            return RedirectToAction("Index", "Home");
        }

        //AllowAnonymous permite o usuário clicar neste botão sem precisar de um Login. Atualmente sem função definida.
        [AllowAnonymous]
        public IActionResult Voltar()
        {
            return RedirectToAction("Index","Home");
        }
    }
}