using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitary
{
    [Serializable]
    [Table("servicio", Schema = "salon_de_belleza")]
    public class Servicio
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nombre")]
        public string  Nombre { get; set; }
        [Column("rango_tiempo")]
        public int RangoTiempo { get; set; }
    }
}
