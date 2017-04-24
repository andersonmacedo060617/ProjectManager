
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
                if (UsuarioUtils.Logar(usuario.Login, usuario.Senha))
                {
                    return RedirectToAction("Principal", "Home");
                }
            }

            return View();
        }

        public ActionResult SemAcesso()
        {
            if(UsuarioUtils.Usuario != null)
            {
                TempData["MSG_FalhaExecucao"] = "Você não tem acesso a está opção";
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Administrador")]
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