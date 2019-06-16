using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscolaTCC.Models;
using EscolaTCC.Models.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscolaTCC.Controllers
{
    public class EnderecoController : Controller
    {
        Endereco end = new Endereco();
        EnderecoDal endDal = new EnderecoDal();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(IFormCollection frm)
        {
            //ModelState.IsValid : eu li que o atributo "asp-for" presente nas tags já direcionava os dados automaticamente para o Model.
            //Porém, isso não funcionou. Logo, tive que injetar manualmente os dados das tags para os atributos do Model.
            if (ModelState.IsValid)
            {
                 end.No_Cep = Convert.ToInt32(frm["Cep"]);
                 end.Nm_Logra = Convert.ToString(frm["Logradouro"]);
                 end.Nm_Bairro = Convert.ToString(frm["Bairro"]); ;
                 end.Nm_Cidade = Convert.ToString(frm["Cidade"]);
                 end.Sg_Uf = Convert.ToString(frm["Uf"]);


                //Aqui eu instancio o método da classe para uma variável para poupar processamento.
                //Só necessitarei do retorno do método e não de seu processamento.
                string retornoCadastroEndereco = endDal.CadastroEndereco(end);

                if (retornoCadastroEndereco == "Sim")
                {
                    //Caso o CEP esteja cadastrado.
                    ViewData["ResultadoEndereco"] = 1;
                    return View();
                }
                else if(retornoCadastroEndereco == "Nao")
                {
                    //Dados Vazios
                    ViewData["ResultadoEndereco"] = 2;
                    return View();
                }
                else
                {
                    //Se der certo.
                    ViewData["ResultadoEndereco"] = 3;
                    return View();
                }    
            }


            return View();
        }
    }
}