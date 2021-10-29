using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utiitary.DTO;
using Utilitary.DTO;

namespace Api.Controllers
{
    [RoutePrefix("Api")]
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("Registrar/cliente")]
        public IHttpActionResult RegistrarReserva(Dto_Cliente cliente)
        {
            string error = "Los datos son incorrectos, por favor verifique.";

            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var state in ModelState)
                    {
                        foreach (var item in state.Value.Errors)
                        {
                            error += $"{item.ErrorMessage}";
                        }
                    }
                    return BadRequest(error);
                }
                return Ok(new LCliente().registrarCliente(cliente));
            }
            catch (Exception ex)
            {
                error = $"¡Ups!, se presento un error al manejar su solicitud. Error: {ex.Message}";
                var HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(error, System.Text.Encoding.UTF8, "text/plain")
                };
                return ResponseMessage(HttpResponseMessage);
            }
        }
    }
}