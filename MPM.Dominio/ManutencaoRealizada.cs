﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPM.Dominio
{
    public class ManutencaoRealizada
    {
        public TipoManutencao Tipo { get; set; }
        public DateTime Data { get; set; }
        public int Kilometragem { get; set; }
    }
}
