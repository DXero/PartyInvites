using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        private DatoContexto contexto;

        public HomeController(DatoContexto ctx) => contexto = ctx;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Respond() => View();

        [HttpPost]
        public IActionResult Respond(InvitadoRespuesta respuesta) {
            contexto.Respuestas.Add(respuesta);
            contexto.SaveChanges();
            //return RedirectToAction(nameof(Thanks), new InvitadoRespuesta() { Name = respuesta.Name, WillAttend = respuesta.WillAttend });
            return RedirectToAction(nameof(Thanks), respuesta);
        }

        public IActionResult Thanks(InvitadoRespuesta respuesta) => View(respuesta);

        public IActionResult ListResponses() => View(contexto.Respuestas.OrderByDescending(r => r.WillAttend));
    }
}