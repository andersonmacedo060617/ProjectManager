using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoTeste.WebSite.Controllers
{
    public class ComponentePageController : Controller
    {
        // GET: ComponentePage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BotoesAcaoIndex(string NameController, int Id, string Entidade)
        {
            ViewBag.Controller = NameController;
            ViewBag.Id = Id;
            ViewBag.Entidade = Entidade;

            return PartialView("_BotoesAcaoIndex");
        }
    }
}