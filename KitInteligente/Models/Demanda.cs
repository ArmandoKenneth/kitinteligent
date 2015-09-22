﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitInteligente.Models
{
    public class Demanda
    {
        public int DemandaID { get; set; }
        public double Valor { get; set; }
        public int Periodo { get; set; }

        // Foreign keys
        public int CalcEstoqueSeg { get; set; }

        // Virtual objects

    }
}