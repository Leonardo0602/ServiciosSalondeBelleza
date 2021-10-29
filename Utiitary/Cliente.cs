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
    [Table("usuario", Schema = "salon_de_belleza")]
    public class Cliente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("cedula")]
        public string Cedula { get; set; }
    }
}
