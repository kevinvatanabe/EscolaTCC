using System.Collections.Generic;
using System.Diagnostics;
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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
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


        //Lucas - Exemplo de Consulta.
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
