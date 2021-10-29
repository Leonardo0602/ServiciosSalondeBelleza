using System;
using System.Linq;
using Utilitary;
using Utilitary.DTO;

namespace Data
{
    public class DCliente
    {
        Mapeo database = new Mapeo();
        public Alerta RegistrarCliente(Cliente cliente) 
        {
            Alerta mensaje = new Alerta();

            if (cliente != null)
            {
                database.Clientes.Add(cliente);
                database.SaveChanges();
                mensaje.respuesta = "Usuario Registrado";
            }
            else 
            {
                mensaje.respuesta = "Error: No se pudo hacer el registro";
            }

            return mensaje;
        }

        public bool VerificarCliente(Dto_Cliente cliente) 
        {
            Cliente client = database.Clientes.Where(c => c.Nombre.Equals(cliente.Nombre) && c.Cedula.Equals(cliente.Cedula)).FirstOrDefault();

            if (client != null)
            {
                return true;
            }
            else 
            {
                return false;  
            }
        }
    }
}
