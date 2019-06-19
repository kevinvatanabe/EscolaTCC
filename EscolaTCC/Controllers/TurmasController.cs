using System.Collections.Generic;
using System.Data;
using EscolaTCC.Models;
using EscolaTCC.Models.DAL;
using EscolaTCC.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace EscolaTCC.Controllers
{
    public class TurmasController : Controller
    {
        [HttpGet]
        // GET: Turmas
        public ActionResult Index()
        {
            Conexao con = new Conexao();
            MySqlCommand msc = new MySqlCommand("Select * from tblturma", con.conectarBD());
            MySqlDataAdapter adapter = new MySqlDataAdapter(msc);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            List<Turma> listTurma = new List<Turma>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Turma turma = new Turma();
                turma.cdTurma = int.Parse(dr["cdTurma"].ToString());
                turma.nmTurma = dr["nmTurma"].ToString();
                turma.dsSerie = dr["dsSerie"].ToString();
                listTurma.Add(turma);
            }

            return View(listTurma);
        }

        // GET: Turmas/Details/5
        public ActionResult Details(int id)
        {
            //Em detalhes será carregado uma relação de 
            return View();
        }

        [HttpGet]
        // GET: Turmas/Create
        public ActionResult Cadastro()
        {
            return View();
        }

        // POST: Turmas/Cadastro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(Turma turma)
        {
            try
            {
                TurmaDal turmaDal = new TurmaDal();
                string retornoCadastro = turmaDal.CadastroTurma(turma);

                if (retornoCadastro == "Sim")
                {
                    ViewData["ResultadoTurma"] = 1;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["ResultadoTurma"] = 2;
                    return View(ViewData["ResultadoTurma"]);
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Turmas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Turmas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Turmas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Turmas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}