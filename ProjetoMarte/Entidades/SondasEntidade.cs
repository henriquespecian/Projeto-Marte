using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoMarte.Entidades
{
    public class SondasEntidade
    {
        public int? PosicaoInicialX { get; set; }

        public int? PosicaoInicialY { get; set; }

        public string Movimento { get; set; }

        public string DirecaoInicial { get; set; }
    }
}