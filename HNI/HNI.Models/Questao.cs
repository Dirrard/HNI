using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI.Models
{
    public class Questao
    {
        public int Id { get; set; }
        public Cena Cena { get; set; }
        public Personagem Personagem { get; set; }
        public  string Descricao { get; set; }
   
    }
}
