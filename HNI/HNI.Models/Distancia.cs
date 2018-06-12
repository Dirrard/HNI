using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI.Models
{
    public class Distancia
    {
        public Lugar Inicial{ get; set; }
        public Lugar Final { get; set; }
        public int Passos { get; set; }
        public int Id { get; set; }
    }
}
