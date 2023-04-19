using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Adjunto
    {
        public int AdjuntoId { get; set; }
        public int PerfilCVId { get; set; }
        public string CV { get; set; }
        public string Presentacion { get; set; }

        public PerfilCV PerfilCV { get; set; }
    }
}
