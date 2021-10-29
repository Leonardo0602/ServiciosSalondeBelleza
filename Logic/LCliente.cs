using Data;
using System;
using Utilitary;
using Utilitary.DTO;

namespace Logic
{
    public class LCliente
    {
        public Alerta registrarCliente(Dto_Cliente cliente) 
        {
            Alerta mensaje = new Alerta();
            bool bandera = new DCliente().VerificarCliente(cliente);

            if (bandera != true)
            {
                Cliente nuevo = new Cliente();
                nuevo.Nombre = cliente.Nombre.ToLower();
                nuevo.Cedula = cliente.Cedula;
                mensaje = new DCliente().RegistrarCliente(nuevo);
            }
            else 
            {
                mensaje.respuesta = "Ya se encuentra registrado";
            }

            return mensaje;
        }
    }
}
