using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EscolaTCC.Models;
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

        // GET: Turmas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Turmas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
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