using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitary.DTO
{
    public class Dto_Servicio
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El tiempo es requerido")]
        public int RangoTiempo { get; set; }
    }
}
