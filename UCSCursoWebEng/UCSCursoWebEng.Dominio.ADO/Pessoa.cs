using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSCursoWebEng.Dominio
{
    public class Pessoa
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public String Sobrenome { get; set; }

        public Pessoa(string id, string nome, string sobrenome)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public Pessoa()
        {

        }
    }
}
