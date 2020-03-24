using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using DispositivosAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static DispositivosAPI.Model.Parametros;

namespace DispositivosAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("Solicitud")]
    [ApiController]
    public class SolicitudController : ApiController
    {
        private readonly AccesoDatos Ac = new AccesoDatos();

        [Microsoft.AspNetCore.Mvc.HttpGet(Name = "Solicitudes_Dispositivos_Lista")]
        [Microsoft.AspNetCore.Mvc.Route("Afiliado_Cedula_Consulta")]
        public IEnumerable<Parametros_Cuidadano_Cedula_Consulta> Afiliado_Cedula_Consulta(string Afiliado_Cedula, string Usuario_Cuenta)
        {
            try
            {
                var Lista = (from dt in Ac.Proc_Usuario_Afiliado_Cedula_Consulta(Afiliado_Cedula, Usuario_Cuenta).AsEnumerable()
                             select new Parametros.Parametros_Cuidadano_Cedula_Consulta
                             {
                                 Usuario_Cedula = Convert.ToString(dt["Usuario_Cedula"]),
                                 Usuario_Fecha_Nacimiento = Convert.ToString(dt["Usuario_Fecha_Nacimiento"]),
                                 Usuario_Sexo = Convert.ToString(dt["Usuario_Sexo"]),
                                 Usuario_Nombre_Completo = Convert.ToString(dt["Usuario_Nombre_Completo"]),
                                 Mensaje = Convert.ToString(dt["Mensaje"]),

                             }).ToList();
                
                return Lista;
            }
            catch (Exception ex)
            {
                return null;// Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpGet()]
        [Microsoft.AspNetCore.Mvc.Route("Solicitudes_Dispositivos_Lista")]
        public ActionResult <IEnumerable<Parametros_Solicitudes_Dispositivos_Lista>> Solicitudes_Dispositivos_Lista(int? PageIndex, byte? PageSize, int? Solicitud_Numero, int? Solicitud_Estado_Numero, string Afiliado_Texto, int? Municipio_Numero)
        {
            try
            {
                if (PageIndex == null || PageSize == null)
                {
                    PageIndex = 0;
                    PageSize = 10;
                }
                var Lista = (from dt in Ac.Proc_Solicitudes_Dispositivos_Trans_Paging_Consulta(PageIndex, PageSize, Solicitud_Numero, Solicitud_Estado_Numero, Afiliado_Texto, Municipio_Numero).AsEnumerable()
                             select new Parametros_Solicitudes_Dispositivos_Lista
                             {
                                 Solicitud_Numero = Convert.ToInt32(dt["Solicitud_Numero"]),
                                 Afiliado_Cedula = Convert.ToString(dt["Afiliado_Cedula"]),
                                 Afiliado_NSS = Convert.ToInt32(dt["Afiliado_NSS"]),
                                 Afiliado_Nombre = Convert.ToString(dt["Afiliado_Nombre"]),
                                 Municipio_Numero = Convert.ToInt32(dt["Municipio_Numero"]),
                                 Municipio_Provincia_Nombre = Convert.ToString(dt["Municipio_Provincia_Nombre"]),
                                 Solicitud_Estado_Numero = Convert.ToInt32(dt["Solicitud_Estado_Numero"]),
                                 Solicitud_Estado_Descripcion = Convert.ToString(dt["Solicitud_Estado_Descripcion"]),
                                 Solicitud_Fecha = Convert.ToString(dt["Solicitud_Fecha"]),
                                 Linea = Convert.ToInt32(dt["Linea"]),
                                 Cantidad_Registros = Convert.ToString(dt["Cantidad_Registros"]),
                                 Class_label = Convert.ToString(dt["Class_label"]),
                                 

                             }).ToList();
                             
                return Lista;
            }
            catch (Exception)
            {
                return null;
            }
        }
       
        [Microsoft.AspNetCore.Mvc.Route("Solicitud_Inserta")]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public Microsoft.AspNetCore.Mvc.ActionResult Solicitud_Inserta([Microsoft.AspNetCore.Mvc.FromBody]Parametros_Solicitud_Dispositivo Solicitud)
        {
            try
            {
               var solicit = (from dt in Ac.Proc_Dispositivos_Solicitudes_Trans_Inserta(Solicitud).AsEnumerable()
                 select new Parametros_Solicitud_Respuesta
                 {
                     Solicitud_Numero = Convert.ToInt32(dt["Solicitud_Numero"]),
                     Mensaje = Convert.ToString(dt["Mensaje"]),
                 }).ToList().FirstOrDefault();

                return new CreatedAtRouteResult("Solicitudes_Dispositivos_Lista", new {solicit.Solicitud_Numero }, solicit);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Microsoft.AspNetCore.Mvc.Route("Solicitud_Actualiza_CIE10_Diagnostico")]
        [Microsoft.AspNetCore.Mvc.HttpPut]
        public Microsoft.AspNetCore.Mvc.ActionResult Solicitud_Actualiza_CIE10_Diagnostico([Microsoft.AspNetCore.Mvc.FromBody]Parametros_Dispositivos_CIE10_Actualiza Solicitud)
        {
            try
            {
                var solicit = (from dt in Ac.Proc_Solicitudes_Dispositivos_Trans_CIE10_Actualiza(Solicitud).AsEnumerable()
                               select new Parametros_Dispositivos_CIE10_Actualiza
                               {
                                   Solicitud_Numero = Convert.ToInt32(dt["Solicitud_Numero"]),
                                   Mensaje = Convert.ToString(dt["Mensaje"]),
                               }).ToList().FirstOrDefault();

                return new CreatedAtRouteResult("Solicitudes_Dispositivos_Lista", new { solicit.Solicitud_Numero }, solicit);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}