using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitary;
using Data;
using Utiitary.DTO;

namespace Logic
{
    public class LReserva
    {
        public Alerta RegistrarReserva(Dto_Reserva booking) 
        {
            DateTime finReseva = new DateTime(2021,10,26,01,01,01);

            Alerta mensaje = new Alerta();
            Reserva reserve = new Reserva();

            bool resp = false;
            Servicio serv = new DServicio().BuscarRegistroServicioxId(booking.IdServicio);
           
            Especialista empleado = new DEspecialista().BuscarDatosDelEspecialistaxId(booking.IdEspecialista);

            if (int.Parse(booking.Hora.ToString("HH")) >= int.Parse(empleado.HoraInicio.ToString("HH"))
                && int.Parse(booking.Hora.ToString("HH")) <= int.Parse(empleado.HoraFin.ToString("HH")))
            {
                var listaReservas = new DReserva().ReservasxEspecialistas(booking.IdEspecialista);

                if (listaReservas != null)
                {
                    foreach (var reserva in listaReservas)
                    {
                        if (booking.Hora.ToString("HH") == reserva.HoraInicio.ToString("HH")
                            && finReseva.ToString("HH") == reserva.HoraFin.ToString("HH"))
                        {
                            mensaje.respuesta = "Error: Ya existe una reserva para esa hora";
                            resp = true;
                        }

                    }

                    if (resp != true)
                    {
                        bool bandera = new DReserva().VerificarReserva(booking);

                        if (bandera != true)
                        {
                            if ( booking.HoraSolicitud.AddHours(1) <= booking.Hora)
                            {
                                reserve.IdUsuario = booking.IdUsuario;
                                reserve.IdEspecialista = booking.IdEspecialista;
                                reserve.IdServicio = booking.IdServicio;
                                reserve.HoraInicio = booking.Hora;
                                reserve.HoraFin = booking.Hora.AddMinutes(serv.RangoTiempo);
                                bool respuesta = new DReserva().RegistrarReserva(reserve);

                                if (respuesta != true)
                                {
                                    mensaje.respuesta = "Error inesperado: No se pudo registrar la reserva";
                                }
                                else
                                {
                                    mensaje.respuesta = "Reserva registrada corectamente";
                                }
                            }
                            else 
                            {
                                mensaje.respuesta = "No se puede hacer la reserva, debes generar la solicitud con al menos una hora de anticipación";
                            }
                        }
                        else 
                        {
                            mensaje.respuesta = "Error: ya existe una reserva para la misma hora con el mismo especialista";
                        }
                        
                    }
                    else 
                    {
                        mensaje.respuesta = "Error: No se pudo registrar la reserva";
                    }
                }
                
            }
            else
            {
                mensaje.respuesta = "La hora no es valida para el rango de tiempo en que labora el especialista";
            }
            return mensaje;
        }

        public List<Reserva> ReservasDelEspecialista(int id) 
        {
            List<Reserva> lista = new DReserva().ReservasxEspecialistas(id);
            return lista;
        }
    }
}
