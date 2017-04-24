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

        [Authorize(Roles = "Administrador")]
        public ActionResult Novo()
        {
            Cliente cliente = new Cliente();

            if(TempData["ClienteReturn"] != null)
            {
                cliente = TempData["ClienteReturn"] as Cliente;
            }

            return View(cliente);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult Gravar(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
               
                TempData["ClienteReturn"] = cliente;
                return RedirectToAction("Novo", "Cliente");
            }

            ConfigDB.Instance.ClienteRepository.Gravar(cliente);

            return RedirectToAction("Index", "Cliente");
        }

        [Authorize(Roles = "Administrador, Usuario")]
        public ActionResult Exibir(int id)
        {
            var cliente = ConfigDB.Instance.ClienteRepository.BuscarPorId(id);
            if(cliente == null)
            {
                return RedirectToAction("Index", "Cliente");
            }

            return View(cliente);
        }

    }

}