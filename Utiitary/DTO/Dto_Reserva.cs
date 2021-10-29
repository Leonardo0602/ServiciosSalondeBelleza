using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiitary.DTO
{
    public class Dto_Reserva
    {
        public int IdUsuario { get; set; }
        public int IdEspecialista { get; set; }
        public int IdServicio { get; set; }
        public DateTime HoraSolicitud { get; set; }
        public DateTime Hora { get; set; }
    }
}
