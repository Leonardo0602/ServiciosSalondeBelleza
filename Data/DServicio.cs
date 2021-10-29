using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitary;
using Utilitary.DTO;

namespace Data
{
    public class DServicio
    {
        Mapeo database = new Mapeo();

        public Alerta RegistrarServicio(Servicio serv)
        {
            Alerta mensaje = new Alerta();

            if (serv != null)
            {
                database.Servicios.Add(serv);
                database.SaveChanges();
                mensaje.respuesta = "Servicio registrado";
            }
            else 
            {
                mensaje.respuesta = "Error: servicio nulo";
            }
            return mensaje;
        }

        public bool VerificarServicio(Dto_Servicio servicio) 
        {
            Servicio serv = database.Servicios.Where(x => x.Nombre.Equals(servicio.Nombre.ToLower())).FirstOrDefault();

            if (serv != null)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public Servicio BuscarRegistroServicioxId(int id) 
        {
            Servicio registroEncontrado = database.Servicios.Where(x => x.Id.Equals(id)).FirstOrDefault();
            return registroEncontrado;
        }
    }
}
