using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCSCursoWebEng.Models
{
    public class PessoaModel
    {

        public string Id { get; set; }
        public string Nome { get; set; }
        public String Sobrenome { get; set; }

        public PessoaModel(string id, string nome, string sobrenome)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public PessoaModel()
        {
            
        }

    }
}