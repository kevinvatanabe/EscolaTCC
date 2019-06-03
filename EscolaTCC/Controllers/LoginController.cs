﻿using System;
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
        public IActionResult Index()
        {
            return View();
        }

 

        public IActionResult Voltar()
        {
            return RedirectToAction("Index","Home");
        }
    }
}