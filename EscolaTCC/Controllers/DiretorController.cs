using System;
using EscolaTCC.Models;
using EscolaTCC.Models.BLL;
using EscolaTCC.Models.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscolaTCC.Controllers
{
    public class DiretorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection frm)
        {
            if (ModelState.IsValid)
            {
                Funcionario func = new Funcionario();
                FuncCargo funcCargo = new FuncCargo();
                Login login = new Login();

                FuncionarioDal funcDal = new FuncionarioDal();

                func.No_CepFunc = Convert.ToInt32(frm["Cep"]);
                func.Nm_Func = Convert.ToString(frm["Nome"]);
                func.No_CpfFunc = Int64.Parse(frm["Cpf"]);
                func.No_RgFunc = Int64.Parse(frm["Rg"]);
                func.Rg_DigFunc = Convert.ToString(frm["Dig"]);
                func.No_TelFunc = Int64.Parse(frm["Tel"]);
                func.Nm_EmailFunc = Convert.ToString(frm["Email"]);
                func.Dt_NascFunc = Convert.ToDateTime(frm["Nasc"]);
                func.No_EndFunc = Convert.ToInt32(frm["Numero"]);
                func.Ds_CompleFunc = Convert.ToString(frm["Comple"]);

                funcCargo.No_Salario = Convert.ToInt32(frm["Salario"]);
                funcCargo.dsFormacao = Convert.ToString(frm["Formacao"]);

                login.NmEmail = Convert.ToString(frm["Conta"]);
                login.NmSenha = Convert.ToString(frm["Senha"]);

                int cdCargo = 4;

                string resultado = funcDal.InsertFuncNovo(func, funcCargo, login, cdCargo);

                if (resultado == "Sim")
                {
                    //Caso o cadastro dê certo.
                    ViewData["ResultadoFuncionario"] = 1;
                    return View();
                }
                else if (resultado == "Erro1")
                {
                    //Cpf já cadastrado
                    ViewData["ResultadoFuncionario"] = 2;
                    return View();
                }
                else
                {
                    //Erro inesperado
                    ViewData["ResultadoFuncionario"] = 3;
                    return View();
                }

            }
            return View();
        }


        public IActionResult Consulta()
        {
            FuncionarioDal funcDal = new FuncionarioDal();
            
            return View(funcDal.SelectAllDiretores());
        }
        public IActionResult Editar()
        {

            return View();
        }

        public IActionResult Excluir(int id)
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            return View();
        }
    }
}