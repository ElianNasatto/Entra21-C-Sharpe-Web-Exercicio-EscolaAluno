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

        public ActionResult Cadastrar(string nome)
        {
            Escola escola = new Escola();
            escola.Nome = nome;
            repository.Inserir(escola);
            return RedirectToAction("index");
        }

        public ActionResult Cadastro()
        {

            return View();
        }

        public ActionResult Update(int id,string nome)
        {
            Escola escola = new Escola();
            escola.Id= id;
            escola.Nome = nome;
            repository.Alterar(escola);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Escola escola = repository.ObterPeloID(id);
            ViewBag.Escola = escola;
            return View();
        }

        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}