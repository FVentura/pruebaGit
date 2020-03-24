using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static DispositivosAPI.Model.Parametros;

namespace DispositivosAPI.Model
{
    public class AccesoDatos
    {
       readonly string con = ("Data Source=DESARROLLOSRV;Initial Catalog=Dispositivos;user id=fpeguero;password=123456789;");

        public DataTable Proc_Dispositivos_Solicitudes_Trans_Inserta(Parametros_Solicitud_Dispositivo Dispositivos)
        {            
            SqlConnection cn = new SqlConnection(con);
            cn.Open();
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "Proc_Dispositivos_Solicitudes_Trans_Inserta";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Solicitante_Cedula", Dispositivos.Solicitante_Cedula);
                //cmd.Parameters.AddWithValue("@Solicitante_Telefono", Dispositivos.Solicitante_Telefono);
                cmd.Parameters.AddWithValue("@Solicitante_Correo_Electronico", Dispositivos.Solicitante_Correo_Electronico);
                cmd.Parameters.AddWithValue("@Afiliado_Cedula", Dispositivos.Afiliado_Cedula);
                cmd.Parameters.AddWithValue("@Afiliado_Telefono", Dispositivos.Afiliado_Telefono);
                cmd.Parameters.AddWithValue("@Afiliado_Correo_Electronico", Dispositivos.Afiliado_Correo_Electronico);
                cmd.Parameters.AddWithValue("@Afiliado_NSS", Dispositivos.Afiliado_NSS);
                cmd.Parameters.AddWithValue("@Afiliado_Nombre", Dispositivos.Afiliado_Nombre);
                cmd.Parameters.AddWithValue("@Afiliado_Fecha_Nacimiento", Dispositivos.Afiliado_Fecha_Nacimiento);
                cmd.Parameters.AddWithValue("@Afiliado_Sexo", Dispositivos.Afiliado_Sexo);
                cmd.Parameters.AddWithValue("@Afiliado_Direccion", Dispositivos.Afiliado_Direccion);
                cmd.Parameters.AddWithValue("@Afiliado_Sector", Dispositivos.Afiliado_Sector);
                cmd.Parameters.AddWithValue("@Municipio_Numero", Dispositivos.Municipio_Numero);

                // cmd.Parameters.AddWithValue("@Afiliado_Disponibilidad_Monto", Dispositivos.Afiliado_Disponibilidad_Monto);
                // cmd.Parameters.AddWithValue("@CIE10_Diagnostico_Codigo_1", Dispositivos.CIE10_Diagnostico_Codigo_1);
                // cmd.Parameters.AddWithValue("@CIE10_Diagnostico_Codigo_2", Dispositivos.CIE10_Diagnostico_Codigo_2);
                // cmd.Parameters.AddWithValue("@Plan_Tipo_Numero", Dispositivos.Plan_Tipo_Numero);
                // cmd.Parameters.AddWithValue("@Solicitud_Observacion", Dispositivos.Solicitud_Observacion);
                // cmd.Parameters.AddWithValue("@Solicitud_Estado_Numero", Dispositivos.Solicitud_Estado_Numero);
                // cmd.Parameters.AddWithValue("@Proveedor_Numero", Dispositivos.Proveedor_Numero);
                // cmd.Parameters.AddWithValue("@Registro_Usuario", Dispositivos.Registro_Usuario);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Dispositivos_Tipo_Cata_Consulta()
        {
            //string conection = configuration.GetConnectionString("Server=DESARROLLOSRV;Database=Dispositivos;User ID=Fpeguero;Password=123456789;MultipleActiveResultSets=true");

            //string con = ("Data Source=DESARROLLOSRV;Initial Catalog=Dispositivos;user id=fpeguero;password=123456789;");

            //var appSettingsJson = GetSettings();
            //var conetstring = appSettingsJson["ConnectionStrings:Conn"];

           // var conet = ConfigurationManager.AppSettings["Conn"];


            SqlConnection cn = new SqlConnection(con);
            cn.Open();
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "Proc_Dispositivos_Tipo_Cata_Consulta";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Proc_Usuario_Afiliado_Cedula_Consulta(string Afiliado_Cedula, string Usuario_Cuenta)
        {
            SqlConnection cn = new SqlConnection(con);
            cn.Open();
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "Proc_Usuario_Afiliado_Cedula_Consulta";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Afiliado_Cedula", Afiliado_Cedula);
                cmd.Parameters.AddWithValue("@Usuario_Cuenta", Usuario_Cuenta);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Proc_Solicitudes_Dispositivos_Trans_Paging_Consulta(int? PageIndex, byte? PageSize, int? Solicitud_Numero, int? Solicitud_Estado_Numero, string Afiliado_Texto, int? Municipio_Numero)
        {
            SqlConnection cn = new SqlConnection(con);
            cn.Open();
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "Proc_Solicitudes_Dispositivos_Trans_Paging_Consulta";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageIndex", PageIndex);
                cmd.Parameters.AddWithValue("@PageSize", PageSize);
                cmd.Parameters.AddWithValue("@Solicitud_Numero", Solicitud_Numero);
                cmd.Parameters.AddWithValue("@Solicitud_Estado_Numero", Solicitud_Estado_Numero);
                cmd.Parameters.AddWithValue("@Afiliado_Texto", Afiliado_Texto);
                cmd.Parameters.AddWithValue("@Municipio_Numero", Municipio_Numero);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Proc_Municipios_Cata_Lista(int? Municipio_Numero)
        {
            SqlConnection cn = new SqlConnection(con);
            cn.Open();
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "Proc_Municipios_Cata_Lista";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Municipio_Numero", Municipio_Numero);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Proc_Proveedores_Master_Lista(int? Proveedor_Numero)
        {
            SqlConnection cn = new SqlConnection(con);
            cn.Open();
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "Proc_Proveedores_Master_Lista";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Proveedor_Numero", Proveedor_Numero);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Proc_Solicitudes_Estados_Cata_Lista(int? Solicitud_Estado_Numero)
        {
            SqlConnection cn = new SqlConnection(con);
            cn.Open();
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "Proc_Solicitudes_Estados_Cata_Lista";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Solicitud_Estado_Numero", Solicitud_Estado_Numero);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Proc_Comunes_CIE10_Diagnosticos_Cata_Consulta(string CIE10_Diagnostico_Codigo)
        {
            SqlConnection cn = new SqlConnection(con);
            cn.Open();
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "Proc_Comunes_CIE10_Diagnosticos_Cata_Consulta";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CIE10_Diagnostico_Codigo", CIE10_Diagnostico_Codigo);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Proc_Solicitudes_Dispositivos_Trans_CIE10_Actualiza(Parametros_Dispositivos_CIE10_Actualiza Dispositivo)
        {
            SqlConnection cn = new SqlConnection(con);
            cn.Open();
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "Proc_Solicitudes_Dispositivos_Trans_CIE10_Actualiza";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Solicitud_Numero", Dispositivo.Solicitud_Numero);
                cmd.Parameters.AddWithValue("@CIE10_Diagnostico_Codigo_1", Dispositivo.CIE10_Diagnostico_Codigo_1);
                cmd.Parameters.AddWithValue("@CIE10_Diagnostico_Codigo_2", Dispositivo.CIE10_Diagnostico_Codigo_2);
                cmd.Parameters.AddWithValue("@Registro_Usuario", Dispositivo.Registro_Usuario);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Proc_Citas_Trans_Inserta(Parametros_Citas_Inserta Cita)
        {
            SqlConnection cn = new SqlConnection(con);
            cn.Open();
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "Proc_Citas_Trans_Inserta";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Solicitud_Numero", Cita.Solicitud_Numero);
                cmd.Parameters.AddWithValue("@Cita_Fecha", Cita.Cita_Fecha);
                cmd.Parameters.AddWithValue("@Cita_Hora_Desde", Cita.Cita_Hora_Desde);
                cmd.Parameters.AddWithValue("@Cita_Hora_Hasta", Cita.Cita_Hora_Hasta);
                cmd.Parameters.AddWithValue("@Registro_Usuario", Cita.Registro_Usuario);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
