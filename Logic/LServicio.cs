using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitary;
using Utilitary.DTO;

namespace Logic
{
    public class LServicio
    {
        public Alerta RegistrarServicio(Dto_Servicio serv) 
        {
            Alerta mensaje = new Alerta();
            bool bandera = new DServicio().VerificarServicio(serv);

            if (bandera != true)
            {
                int minutosMax = 59;
                int minutosMin = 20;

                int rango = minutosMax - serv.RangoTiempo;

                if (rango >= minutosMin && rango <= minutosMax)
                {
                    Servicio servicio = new Servicio
                    {
                        Nombre = serv.Nombre.ToLower(),
                        RangoTiempo = serv.RangoTiempo
                    };

                    mensaje = new DServicio().RegistrarServicio(servicio);
                }
                else 
                {
                    mensaje.respuesta = "El servicio no cumple con el rango en minutos de trabajo";
                }
            }
            else 
            {
                mensaje.respuesta = "El servicio ya esta registrado";
            }

            return mensaje;
        }
    }
}
