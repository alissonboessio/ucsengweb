using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCSCursoWebEng.Models;
using UCSCursoWebEng.Repositories;

namespace UCSCursoWebEng.Controllers
{
    public class HomeController : Controller
    {

        private PessoaModel CriarPessoa(int i)
        {
            return
                new PessoaModel(
                    Guid.NewGuid().ToString(),
                    $"Nome da pessoa {i}",
                    $"Sobrenome da pessoa {i}"
                );
        }

        private List<PessoaModel> CriarLista()
        {
            var r = new List<PessoaModel>();

            for (int i = 0; i < 15; i++)
            {
                r.Add(CriarPessoa(i));
            }

            return r;
        }


        public ActionResult Index()
        {

            List<PessoaModel> listaDePessoas = new List<PessoaModel>();

            PessoaADO pessoaADO = new PessoaADO();

            listaDePessoas = pessoaADO.GetAll();

            //var listaDePessoas = CriarLista();

            
            return View(listaDePessoas);
        }

        //quando nao esta definido, é tratado como Get.
        //entao, passamos o id por url parameter
        public ActionResult Detalhe(string id)
        {
            PessoaModel pessoa;

            if (!String.IsNullOrEmpty(id))
            {
                PessoaADO pessoaADO = new PessoaADO();
                pessoa = pessoaADO.GetById(id);

            }
            else
            {
                pessoa = new PessoaModel();
            }

            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Detalhe(PessoaModel pessoa)
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