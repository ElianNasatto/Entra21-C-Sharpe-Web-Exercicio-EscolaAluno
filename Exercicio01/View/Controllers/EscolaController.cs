using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class EscolaController : Controller
    {
        EscolaRepository repository = new EscolaRepository();

        // GET: Escola
        public ActionResult Index()
        {
            List<Escola> escolas = repository.ObterTodos();

            ViewBag.Escola = escolas;
            return View();
        }
    }
}