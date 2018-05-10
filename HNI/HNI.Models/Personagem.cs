using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI.Models
{
    public class Personagem
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public  Classe Classe { get; set; }
        public string Imagem { get; set; }
        public string  Nome { get; set; }
        public string Genero { get; set; }
        public int ouro { get; set; }
        public int Mana { get; set; }
        public int Hp { get; set; }
        public int AtkF { get; set; }
        public int AtkM { get; set; }
        public int Def { get; set; }
        public int Nivel { get; set; }
        public int Exp{ get; set; }
    }
}
