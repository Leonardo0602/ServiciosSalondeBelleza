using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utiitary.DTO;

namespace Api.Controllers
{
    [RoutePrefix("Api")]
    public class ReservaController : ApiController
    {
        [HttpPost]
        [Route("Registrar/Reserva")]
        // GET api/<controller>
        public IHttpActionResult RegistrarReserva(Dto_Reserva booking)
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
                return Ok(new LReserva().RegistrarReserva(booking));
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

        [HttpGet]
        [Route("Registrar/Reserva")]
        // GET api/<controller>
        public IHttpActionResult VerReservasDelEspecialista(int id)
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
                return Ok(new LReserva().ReservasDelEspecialista(id));
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