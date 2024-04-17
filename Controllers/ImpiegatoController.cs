using Microsoft.AspNetCore.Mvc;
using TaskImpiegati.Models;
using TaskImpiegati.Services;

namespace TaskImpiegati.Controllers
{
    public class ImpiegatoController : Controller
    {

        private readonly ImpiegatoService _service;

        public ImpiegatoController(ImpiegatoService service)
        {
            _service = service;
        }
        public IActionResult Lista()
        {
            List<Impiegato> elenco = _service.ElencoTuttiImpiegati();

            return View(elenco);
        }
        public IActionResult Inserimento()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Salvataggio(Impiegato objImpiegato)
        {
            if (_service.InserisciImpiegato(objImpiegato))
                return Redirect("/Impiegato/Lista");
            else
                return Redirect("/Impiegato/Errore");
        }
        public IActionResult Dettaglio(string varMatricola)
        {
            if (string.IsNullOrWhiteSpace(varMatricola))
                return Redirect("/Impiegato/Errore");

            Impiegato? impiegato = _service.RicercaImpiegatoPerMatricola(varMatricola);
            if (impiegato is null)
                return Redirect("/Impiegato/Errore");

            return View(impiegato);
        }

        [HttpDelete]
        public IActionResult Elimina(string varMatricola)
        {
            if (_service.EliminaImpiegatoPerMatricola(varMatricola))
                return Ok();

            return BadRequest();
        }

    }
}
