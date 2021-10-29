using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitary;
using Utilitary.DTO;

namespace Data
{
    public class DEspecialista
    {
        readonly Mapeo dataBase = new Mapeo();

        public Alerta RegistrarEspecialista(Especialista empleado) 
        {
            Alerta mensaje = new Alerta();

            if (empleado != null)
            {
                dataBase.Especialistas.Add(empleado);
                dataBase.SaveChanges();
                mensaje.respuesta = "Usuario Registrado";
            }
            else
            {
                mensaje.respuesta = "Error: No se pudo hacer el registro";
            }

            return mensaje;
        }

        public bool VerificarEspecialista(Dto_Especialista empleado)
        {
            Especialista client = dataBase.Especialistas.Where(c => c.Nombre.Equals(empleado.Nombre) && c.Cedula.Equals(empleado.Cedula)).FirstOrDefault();

            if (client != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Especialista BuscarDatosDelEspecialistaxId(int id) 
        {
            Especialista especialistaEncontrado = dataBase.Especialistas.Where(x => x.Id.Equals(id)).FirstOrDefault();
            return especialistaEncontrado;
        }

    }
}
