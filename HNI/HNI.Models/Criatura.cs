using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI.Models
{
    public class Criatura
    {
        public int Id { get; set; }
        public string Imagem { get; set; }
        public string Nome { get; set; }
        public int Mana { get; set; }
        public int Hp { get; set; }
        public int AtkF { get; set; }
        public int AtkM { get; set; }
        public int Def { get; set; }
        public int Ouro { get; set; }
        public string Descricao { get; set; }
        public int Exp { get; set; }
    }
}
