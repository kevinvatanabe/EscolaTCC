using EscolaTCC.Models.DAL;
using Microsoft.AspNetCore.Mvc;

namespace EscolaTCC.Controllers
{
    public class TurmaAlunoController : Controller
    {
        public IActionResult Index(int id)
        {
            TurmaAlunoDal turmaAlunoDal = new TurmaAlunoDal();
            return View(turmaAlunoDal.SelectAlunoTurma(id));
        }
    }
}