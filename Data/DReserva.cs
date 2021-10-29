using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utiitary.DTO;
using Utilitary;

namespace Data
{
    public class DReserva
    {
        Mapeo database = new Mapeo();
        public bool RegistrarReserva(Reserva booking) 
        {
            if (booking != null)
            {
                database.Reservas.Add(booking);
                database.SaveChanges();
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool VerificarReserva(Dto_Reserva Booking) 
        {
            var busqueda = database.Reservas.Where(x => x.IdEspecialista.Equals(Booking.IdEspecialista) 
                                                        && x.IdUsuario.Equals(Booking.IdUsuario)
                                                        && x.HoraInicio.Equals(Booking.Hora)).FirstOrDefault();

            if (busqueda != null)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public List<Reserva> ReservasxEspecialistas(int id) 
        {
            return (from re in database.Reservas 
                    join c in database.Clientes on re.IdUsuario equals c.Id
                    join es in database.Especialistas on re.IdEspecialista equals es.Id
                    join se in database.Servicios on re.IdServicio equals se.Id
                    where re.IdEspecialista == id

                    select new
                    {
                        re,
                        c.Nombre,
                        es,
                        se

                    }).ToList().Select(n => new Reserva 
                    {

                        Id = n.re.Id,
                        IdUsuario = n.re.IdUsuario,
                        NombreUsuario = n.Nombre,
                        IdEspecialista = n.es.Id,
                        NombreEspecialista = n.es.Nombre,
                        HoraInicioEspecialista = n.es.HoraInicio,
                        HoraFinEspecialista = n.es.HoraFin,
                        IdServicio = n.se.Id,
                        NombreServicio = n.se.Nombre,
                        HoraServicio = n.se.RangoTiempo,
                        HoraInicio = n.re.HoraInicio,
                        HoraFin = n.re.HoraFin

                    }).OrderBy(X => X.NombreServicio).ToList();
        }
    }
}
