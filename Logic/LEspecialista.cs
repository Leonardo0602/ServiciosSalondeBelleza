using Data;
using System;
using Utilitary;
using Utilitary.DTO;

namespace Logic
{
    public class LEspecialista
    {
        public Alerta RegistrarEspecialista(Dto_Especialista empleado)
        {
            bool bandera = new DEspecialista().VerificarEspecialista(empleado);
            Alerta mensaje = new Alerta();
            DateTime fechainicio = new DateTime(2021, 10, 25, 07, 00, 00);
            DateTime fechaFin = new DateTime(2021, 10, 25, 20, 00, 00);

            int resultadoHora = int.Parse(empleado.HoraFin.ToString("HH")) - int.Parse(empleado.HoraInicio.ToString("HH"));

            if (bandera != true)
            {
                if (resultadoHora >= 6 && resultadoHora <= 10)
                {
                    if (int.Parse(empleado.HoraInicio.ToString("HH")) >= int.Parse(fechainicio.ToString("HH")))
                    {
                        if (int.Parse(empleado.HoraFin.ToString("HH")) <= int.Parse(fechaFin.ToString("HH")))
                        {
                            Especialista nuevo = new Especialista();
                            nuevo.Nombre = empleado.Nombre.ToLower();
                            nuevo.Cedula = empleado.Cedula;
                            nuevo.HoraInicio = empleado.HoraInicio;
                            nuevo.HoraFin = empleado.HoraFin;
                            mensaje = new DEspecialista().RegistrarEspecialista(nuevo);
                        }
                        else
                        {
                            mensaje.respuesta = "El horario debe terminar a las 20:00 o antes de las 20:00";
                        }

                    }
                    else
                    {
                        mensaje.respuesta = "El horario debe empezar a las 7:00 o después de las 7:00";

                    }

                }
                else 
                {
                    mensaje.respuesta = "No cumple con el rango en horas de trabajo";
                }
                
            }
            else
            {
                mensaje.respuesta = "Ya se encuentra registrado";
            }

            return mensaje;
        }
    }
}
