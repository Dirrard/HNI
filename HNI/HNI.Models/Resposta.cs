﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI.Models
{
    public class Resposta
    {
        public int Id { get; set; }
        public Questao Questao { get; set; }
        public string Descricao { get; set; }
        public int Identidade { get; set; }
    }
}