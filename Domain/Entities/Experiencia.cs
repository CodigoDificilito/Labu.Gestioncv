using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Experiencia
    {
        public int ExperienciaId { get; set; }
        public int PerfilCVId { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public PerfilCV PerfilCV { get; set; }
    }
}
