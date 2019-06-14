using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EscolaTCC.Models.ViewsModels;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using EscolaTCC.Models.Data;
using System.Data;
using EscolaTCC.Models;

namespace EscolaTCC.Controllers
{
    public class HomeController : Controller
    {
        //Teste da primeira Session
        const string SessionName = "_Name";

        public IActionResult Index()
        {
            HttpContext.Session.SetString(SessionName, "Foi");

            //Teste de exibição da primeira Session
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Senha = HttpContext.Session.GetString("Senha");
            ViewBag.Autorizacao = HttpContext.Session.GetInt32("Autorizacao");

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


        public ActionResult Turmas()
        {
            Conexao con = new Conexao();
            MySqlCommand msc = new MySqlCommand("Select * from tblturma",con.conectarBD());
            MySqlDataAdapter adapter = new MySqlDataAdapter(msc);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            List<Turma> listTurma = new List<Turma>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                Turma turma = new Turma();
                turma.cdTurma = int.Parse(dr["cdTurma"].ToString());
                turma.nmTurma = dr["cdTurma"].ToString();
                turma.dsSerie = dr["dsSerie"].ToString();
                listTurma.Add(turma);
            }

            return View(listTurma);
        }

    }
}
