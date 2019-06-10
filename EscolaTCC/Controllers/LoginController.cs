using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscolaTCC.Models;
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
        public IActionResult Logar(Login login)
        {
            @ViewBag.Message = "Hello";
            return 
        }

        public IActionResult Voltar()
        {
            return RedirectToAction("Index","Home");
        }
    }
}