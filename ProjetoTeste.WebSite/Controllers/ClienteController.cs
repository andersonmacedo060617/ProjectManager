using ProjetoTeste.NH.Config;
using ProjetoTeste.NH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoTeste.WebSite.Controllers
{
    
    public class ClienteController : Controller
    {
        // GET: Cliente
        [Authorize (Roles ="Usuario, Administrador")]
        public ActionResult Index()
        {
            var clientes = ConfigDB.Instance.ClienteRepository.BuscarTodos();
            return View(clientes);
        }

        [Authorize(Roles = "Usuario, Administrador")]
        public ActionResult Novo()
        {
            Cliente cliente = new Cliente();

            if(TempData["ClienteReturn"] != null)
            {
                cliente = TempData["ClienteReturn"] as Cliente;
            }

            return View(cliente);
        }
    }
    
}