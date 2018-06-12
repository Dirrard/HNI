using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI.Models
{
    public class Momento
    {
        public int Id { get; set; }
        public Cena Cena { get; set; }
        public Lugar Lugar { get; set; }
        public Questao Questao { get; set; }
        public Personagem Personagem { get; set; }
    }
}
