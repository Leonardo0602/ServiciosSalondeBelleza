using Logic;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitary.DTO;

namespace Api.Controllers
{
    [RoutePrefix("Api")]
    public class ServicioController : ApiController
    {
        [HttpPost]
        [Route("Registrar/Servicio")]
        // GET api/<controller>
        public IHttpActionResult RegistrarEspecialista(Dto_Servicio serv)
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
                return Ok(new LServicio().RegistrarServicio(serv));
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