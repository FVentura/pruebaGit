using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using DispositivosAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DispositivosAPI.Model.Parametros;

namespace DispositivosAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("Catalogos")]
    [ApiController]
    public class CatalogosController : ApiController
    {
        private readonly AccesoDatos Ac = new AccesoDatos();

        [Microsoft.AspNetCore.Mvc.HttpGet()]
        [Microsoft.AspNetCore.Mvc.Route("Municipios_Lista")]
        public IEnumerable<Parametros_Municipios_Lista> Municipios_Lista(int? Municipio_Numero)
        {
            try
            {
                var Lista = (from dt in Ac.Proc_Municipios_Cata_Lista(Municipio_Numero).AsEnumerable()
                             select new Parametros_Municipios_Lista
                             {
                                 Municipio_Numero = Convert.ToInt32(dt["Municipio_Numero"]),
                                 Municipio_Nombre = Convert.ToString(dt["Municipio_Nombre"]),

                             }).ToList();

                return Lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        } 
        
        [Microsoft.AspNetCore.Mvc.HttpGet()]
        [Microsoft.AspNetCore.Mvc.Route("Proveedores_Lista")]
        public IEnumerable<Parametros_Proveedores_Lista> Proveedores_Lista(int? Proveedor_Numero)
        {
            try
            {
                var Lista = (from dt in Ac.Proc_Proveedores_Master_Lista(Proveedor_Numero).AsEnumerable()
                             select new Parametros_Proveedores_Lista
                             {
                                 Proveedor_Numero = Convert.ToInt32(dt["Proveedor_Numero"]),
                                 Proveedor_Nombre = Convert.ToString(dt["Proveedor_Nombre"]),
                             }).ToList();

                return Lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpGet()]
        [Microsoft.AspNetCore.Mvc.Route("Diagnosticos_Lista")]
        public IEnumerable<Parametros_Diagnosticos_Lista> Diagnosticos_Lista(string CIE10_Diagnostico_Codigo)
        {
            try
            {
                var Lista = (from dt in Ac.Proc_Comunes_CIE10_Diagnosticos_Cata_Consulta(CIE10_Diagnostico_Codigo).AsEnumerable()
                             select new Parametros_Diagnosticos_Lista
                             {
                                 CIE10_Diagnostico_Codigo = Convert.ToString(dt["CIE10_Diagnostico_Codigo"]),
                                 CIE10_Diagnostico_Descripcion = Convert.ToString(dt["CIE10_Diagnostico_Descripcion"]),
                             }).ToList();

                return Lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpGet()]
        [Microsoft.AspNetCore.Mvc.Route("Solicitud_Estado_Lista")]
        public IEnumerable<Parametros_Solicitudes_Estados_Lista> Solicitud_Estado_Lista(int? Solicitud_Estado_Numero)
        {
            try
            {
                var Lista = (from dt in Ac.Proc_Solicitudes_Estados_Cata_Lista(Solicitud_Estado_Numero).AsEnumerable()
                             select new Parametros_Solicitudes_Estados_Lista
                             {
                                 Solicitud_Estado_Numero = Convert.ToInt32(dt["Solicitud_Estado_Numero"]),
                                 Solicitud_Estado_Descripcion = Convert.ToString(dt["Solicitud_Estado_Descripcion"]),
                             }).ToList();

                return Lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}