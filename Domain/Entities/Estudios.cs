using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Estudios
    {
        public int EstudioId { get; set; }
        public int PerfilCVId { get; set; }
        public int TipoEstudioId { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public PerfilCV PerfilCV { get; set; }
        public TipoEstudio TipoEstudio { get; set; }
    }
}
