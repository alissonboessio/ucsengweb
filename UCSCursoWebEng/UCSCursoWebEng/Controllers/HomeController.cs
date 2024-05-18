using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCSCursoWebEng.Dados.ADO;
using UCSCursoWebEng.Dominio;

namespace UCSCursoWebEng.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            List<Pessoa> listaDePessoas = new List<Pessoa>();

            PessoaADO pessoaADO = new PessoaADO();

            listaDePessoas = pessoaADO.GetAll();

            
            return View(listaDePessoas);
        }

        //quando nao esta definido, é tratado como Get.
        //entao, passamos o id por url parameter
        public ActionResult Detalhe(string id)
        {
            Pessoa pessoa;

            if (!String.IsNullOrEmpty(id))
            {
                PessoaADO pessoaADO = new PessoaADO();
                pessoa = pessoaADO.GetById(id);

            }
            else
            {
                pessoa = new Pessoa();
            }

            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Detalhe(Pessoa pessoa)
        {
            PessoaADO pessoaADO = new PessoaADO();

            if (string.IsNullOrEmpty(pessoa.Id))
            {
                pessoaADO.Inserir(pessoa);

            }
            else
            {
                pessoaADO.Atualizar(pessoa);

            }



            return RedirectToAction("Index");
        }

        public ActionResult Deletar(string id)
        {
            PessoaADO pessoa = new PessoaADO();

            pessoa.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}