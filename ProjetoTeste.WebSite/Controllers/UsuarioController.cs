using ProjetoTeste.NH.Model;
using ProjetoTeste.WebSite.RolesSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoTeste.WebSite.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Logar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (UsuarioUtils.Logar(usuario.Login, usuario.Senha))
                {
                    return RedirectToAction("Principal", "Home");
                }
            }
            TempData["MSG_FalhaAcesso"] = "Login ou senha invalidos!";

            return RedirectToAction("Index", "Home");
        }
    }
}