
using ProjetoTeste.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProjetoTeste.WebSite.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var usuario = UsuarioUtils.Usuario;
            if (usuario != null) {
                return RedirectToAction("Logar", "Usuario", usuario);
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize (Roles ="Administrador, Usuario")]
        public ActionResult Principal()
        {
            return View();
        }
    }
}