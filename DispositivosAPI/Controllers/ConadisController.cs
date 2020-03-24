using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DispositivosAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DispositivosAPI.Model.Parametros;

namespace DispositivosAPI.Controllers
{
    [Route("Conadis")]
    [ApiController]
    public class ConadisController : ControllerBase
    {
        private readonly AccesoDatos Ac = new AccesoDatos();

        [Route("Cita_Inserta")]
        [HttpPost]
        public ActionResult Cita_Inserta([FromBody]Parametros_Citas_Inserta Cita)
        {
            try
            {
                var result = (from dt in Ac.Proc_Citas_Trans_Inserta(Cita).AsEnumerable()
                               select new Parametros_Citas_Inserta
                               {
                                   Cita_Numero = Convert.ToInt32(dt["Cita_Numero"]),
                                   Solicitud_Numero = Convert.ToInt32(dt["Solicitud_Numero"]),
                                   Cita_Fecha = Convert.ToDateTime(dt["Cita_Fecha"]),
                                   Cita_Hora_Desde = Convert.ToDateTime(dt["Cita_Hora_Desde"]),
                                   Cita_Hora_Hasta = Convert.ToDateTime(dt["Cita_Hora_Hasta"]),
                                   Mensaje = Convert.ToString(dt["Mensaje"]),
                               }).ToList().FirstOrDefault();

                return new CreatedAtRouteResult("Solicitudes_Dispositivos_Lista", new { result.Solicitud_Numero }, result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}