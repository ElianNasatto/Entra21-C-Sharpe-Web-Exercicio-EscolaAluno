using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class AlunoController : Controller
    {
        AlunoRepository repository = new AlunoRepository();
        // GET: Aluno
        public ActionResult Index()
        {
            List<Aluno> alunos = repository.ObterTodos();
            ViewBag.Alunos = alunos;
            return View();
        }

        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Insert(string nome, string cpf, decimal nota1, decimal nota2, decimal nota3)
        {
            Aluno aluno = new Aluno();
            aluno.Nome = nome;
            aluno.Cpf = cpf;
            aluno.Nota_1 = nota1;
            aluno.Nota_2 = nota2;
            aluno.Nota_3 = nota3;
            repository.Inserir(aluno);
            return RedirectToAction("Index");
        }

        public ActionResult Alterar(int id)
        {
            Aluno aluno = repository.ObterPeloId(id);
            ViewBag.Aluno = aluno;
            return View();
        }

        public ActionResult Update(string id, string nome, string cpf,string nota1,string nota2,string nota3)
        {
            Aluno aluno = new Aluno();
            aluno.Id = Convert.ToInt32(id);
            aluno.Nome = nome;
            aluno.Cpf = cpf;
            aluno.Nota_1 = Convert.ToDecimal(nota1);
            aluno.Nota_2 = Convert.ToDecimal(nota2);
            aluno.Nota_3 = Convert.ToDecimal(nota3);
            repository.Alterar(aluno);
            return RedirectToAction("Index");
        }
    }
}