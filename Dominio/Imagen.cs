﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagen
    {
        public int ID_Imagen { get; set; }
        public int ID_Art {  get; set; } 
        public string Url { get; set; }
        public Imagen imagen { get; set; }


    }
}
