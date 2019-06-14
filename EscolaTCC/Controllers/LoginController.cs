﻿using System;
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

        Login login = new Login();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Login login, IFormCollection frm, LoginDal loginDal)
        {
            if (ModelState.IsValid) 
            {
                login.NmEmail = frm["txtEmail"];
                login.NmSenha = frm["txtSenha"];

                //Verifica se é um diretor, secretaria, professor ou responsável
                if (frm["Autorizacao"] == "Professor")
                    login.CdAutorizacao = 1;

                else if (frm["Autorizacao"] == "Responsavel")
                    login.CdAutorizacao = 2;

                else if (frm["Autorizacao"] == "Secretaria")
                    login.CdAutorizacao = 3;
                else
                    login.CdAutorizacao = 4;

                string retornoVerificaLogin = loginDal.VerificaUsuario(login);

                if (retornoVerificaLogin == "Sim")
                {
                  
                    string SessionEmail = login.NmEmail;
                    string SessionSenha = login.NmSenha;
                    int SessionAutorizacao = login.CdAutorizacao;

                    HttpContext.Session.SetString("Email", SessionEmail);
                    HttpContext.Session.SetString("Senha", SessionSenha);
                    HttpContext.Session.SetInt32("Autorizacao", SessionAutorizacao);

                    return RedirectToAction("Index", "Home");
                }
                else if (retornoVerificaLogin == "Nao")
                {
                    ModelState.AddModelError("Erro", "Usuário ou senha incorretos.");
                    return View("Index");
                }
                else
                {
                    ModelState.AddModelError("Erro", "Usuário ou senha incorretos.");
                    return View("Index");
                }

            }
            return View();
        }

        public IActionResult Logoff()
        {

            string SessionEmail = " ";
            string SessionSenha = " ";
            int SessionAutorizacao = 0;

            HttpContext.Session.SetString("Email", SessionEmail);
            HttpContext.Session.SetString("Senha", SessionSenha);
            HttpContext.Session.SetInt32("Autorizacao", SessionAutorizacao);

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult Voltar()
        {
            return RedirectToAction("Index","Home");
        }
    }
}