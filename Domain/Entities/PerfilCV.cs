﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PerfilCV
    {
        public int PerfilCVId { get; set; }
        public int AspiranteId { get; set; }
        public string Descripcion { get; set; }
        public int SalarioMinimo { get; set; }
        public string Imagen { get; set; }

        public Adjunto Adjunto { get; set; }
        public IList<Estudios> Estudios { get; set; }
        public IList<Experiencia> Experiencia { get; set; }
        public IList<Habilidad> Habilidad { get; set; }
    }
}
