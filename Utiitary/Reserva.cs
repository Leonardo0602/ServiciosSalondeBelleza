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
    [Table("reserva", Schema = "salon_de_belleza")]
    public class Reserva
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        [Column("id_especialista")]
        public int IdEspecialista { get; set; }
        [Column("id_servicio")]
        public int IdServicio { get; set; }
        [Column("hora_inicio")]
        public DateTime HoraInicio { get; set; }
        [Column("hora_fin")]
        public DateTime HoraFin { get; set; }

        [NotMapped]
        public string NombreUsuario { get; set; }
        [NotMapped]
        public string  NombreEspecialista { get; set; }
        [NotMapped]
        public string NombreServicio { get; set; }
        [NotMapped]
        public DateTime HoraInicioEspecialista { get; set; }
        [NotMapped]
        public DateTime HoraFinEspecialista { get; set; }
        [NotMapped]
        public int HoraServicio { get; set; }

    }
}
