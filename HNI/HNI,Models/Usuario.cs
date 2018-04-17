using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_Models
{
    class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfSenha { get; set; }
        public int DataNasc { get; set; }
        public string Genero { get; set; }
        public bool Termo { get; set; }
    }
}
