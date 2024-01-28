using Microsoft.AspNetCore.Mvc;
using Reminder.Models;
using System.Collections.Generic;
using System.Reflection;

namespace Reminder.Controllers
{
    public class HomeController : Controller
    {
        private static List<Lembrete> lembretes = new List<Lembrete>();

        public IActionResult Index()
        {
            return View(lembretes);
        }

        [HttpPost]
        public IActionResult AdicionarLembrete(string nome, string data)
        {
            if (DateTime.TryParse(data, out DateTime dataLembrete) && dataLembrete > DateTime.Now)
            {
                var lembrete = new Lembrete { Id = lembretes.Count + 1, Nome = nome, Data = dataLembrete };
                lembretes.Add(lembrete);
            }
            else
            {
                TempData["Erro"] = "A data informada não é válida ou está no passado.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ExcluirLembrete(int lembreteId)
        {
            var excluirLembrete = lembretes.FirstOrDefault(l => l.Id == lembreteId);
            if (excluirLembrete != null)
            {
                lembretes.Remove(excluirLembrete);
            }

            return RedirectToAction("Index");
        }
    }
}
