using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EscolaTCC.Models.ViewsModels;
using Microsoft.AspNetCore.Http;

namespace EscolaTCC.Controllers
{
    public class HomeController : Controller
    {
        const string SessionName = "_Name";
        public IActionResult Index()
        {
            HttpContext.Session.SetString(SessionName, "Foi");

            ViewBag.Email = HttpContext.Session.GetString("Email");

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            ViewBag.Message = HttpContext.Session.GetString(SessionName);


            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
