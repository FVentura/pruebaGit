using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DispositivosAPI.Model
{
    public class Parametros
    {
        public class Parametros_Solicitud_Dispositivo
        {
            public int Solicitud_Numero { get; set; }

            [Required]
            [StringLength(11, MinimumLength = 11, ErrorMessage = "El Campo Cédula debe contener 11 digitos")]
            [DataType(DataType.Text)]
            public string Afiliado_Cedula { get; set; }

            [Required]
            [StringLength(20, MinimumLength = 10, ErrorMessage = "El Numero de telefono debe contener minimo 10 Digitos")]
            [DataType(DataType.Text)]
            public string Afiliado_Telefono { get; set; }

            [Required]
            [StringLength(60, MinimumLength = 10, ErrorMessage = "El Correo Electronico debe contener minimo 10 Caracteres")]
            [DataType(DataType.EmailAddress)]
            public string Afiliado_Correo_Electronico { get; set; }

            [Required]
            public int Afiliado_NSS { get; set; }

            [Required]
            [StringLength(90, MinimumLength = 2, ErrorMessage = "El Nombre del Afiliado no debe ser menor de 2 caracteres o mayor de 90")]
            [DataType(DataType.Text)]
            public string Afiliado_Nombre { get; set; }

            [Required]
            [DataType(DataType.Text)]
            public string Afiliado_Fecha_Nacimiento { get; set; }

            [Required]
            [StringLength(1, MinimumLength = 1, ErrorMessage = "El Sexo del Afiliado Se debe representar con (M) ó (F)")]
            [DataType(DataType.Text)]
            public string Afiliado_Sexo { get; set; }

            [Required]
            [StringLength(300, MinimumLength = 5, ErrorMessage = "La Direccion del Afiliado debe tener Minimo 5 Caracteres")]
            [DataType(DataType.Text)]
            public string Afiliado_Direccion { get; set; }

            [Required]
            [StringLength(150, MinimumLength = 5, ErrorMessage = "El Sector del Afiliado debe tener Minimo 5 Caracteres")]
            [DataType(DataType.Text)]
            public string Afiliado_Sector { get; set; }

            [Required]
            public Decimal Afiliado_Disponibilidad_Monto { get; set; }

            [Required]
            [StringLength(11, MinimumLength = 11, ErrorMessage = "El Campo Cédula del Solicitante debe contener 11 digitos")]
            [DataType(DataType.Text)]
            public string Solicitante_Cedula { get; set; }

            [Required]
            [StringLength(20, MinimumLength = 10, ErrorMessage = "El Numero de telefono del Solicitante debe contener minimo 10 Digitos")]
            [DataType(DataType.Text)]
            public string Solicitante_Telefono { get; set; }

            [Required]
            [StringLength(60, MinimumLength = 10, ErrorMessage = "El Correo Electronico del Solicitante debe contener minimo 10 Caracteres")]
            [DataType(DataType.Text)]
            public string Solicitante_Correo_Electronico { get; set; }

            [StringLength(8, MinimumLength = 8, ErrorMessage = "El Codigo del diagnostico debe contener 8 Caracteres")]
            [DataType(DataType.Text)]
            public string CIE10_Diagnostico_Codigo_1 { get; set; }

            [StringLength(8, MinimumLength = 8, ErrorMessage = "El Codigo del diagnostico debe contener 8 Caracteres")]
            [DataType(DataType.Text)]
            public string CIE10_Diagnostico_Codigo_2 { get; set; }

            [Required]
            public int Plan_Tipo_Numero { get; set; }

            [Required]
            public int Municipio_Numero { get; set; }

            [StringLength(1000)]
            [DataType(DataType.Text)]
            public string Solicitud_Observacion { get; set; }

            [Required]
            public int Solicitud_Estado_Numero { get; set; }

            [Required]
            public int Proveedor_Numero { get; set; }

            [Required]
            public string Registro_Usuario { get; set; }
        }
        public class Parametros_Solicitud_Respuesta
        {
            public int Solicitud_Numero { get; set; }

            public string Mensaje { get; set; }
        }
        public class Parametros_Cuidadano_Cedula_Consulta
        {

            [Required]
            [StringLength(11, MinimumLength = 11, ErrorMessage = "El Campo Cédula debe contener 11 digitos")]
            [DataType(DataType.Text)]
            public string Usuario_Cedula { get; set; }
            
            [Required]
            [DataType(DataType.Text)]
            public string Usuario_Fecha_Nacimiento { get; set; }

            [Required]
            [StringLength(1, MinimumLength = 1, ErrorMessage = "El Sexo del Afiliado Se debe representar con (M) ó (F)")]
            [DataType(DataType.Text)]
            public string Usuario_Sexo { get; set; }
            
            [Required]
            [StringLength(90, MinimumLength = 2, ErrorMessage = "El Nombre del Afiliado no debe ser menor de 2 caracteres o mayor de 90")]
            [DataType(DataType.Text)]
            public string Usuario_Nombre_Completo { get; set; }           
            public string Mensaje { get; internal set; }
        }      
        public class Parametros_Solicitudes_Dispositivos_Lista
        {
            public int Solicitud_Numero { get; set; }

            [Required]
            [StringLength(11, MinimumLength = 11, ErrorMessage = "El Campo Cédula debe contener 11 digitos")]
            [DataType(DataType.Text)]
            public string Afiliado_Cedula { get; set; }

            [Required]
            public int Afiliado_NSS { get; set; }

            [Required]
            [StringLength(90, MinimumLength = 2, ErrorMessage = "El Nombre del Afiliado no debe ser menor de 2 caracteres o mayor de 90")]
            [DataType(DataType.Text)]
            public string Afiliado_Nombre { get; set; }
                      
            [Required]
            public int Municipio_Numero { get; set; }
            public string Municipio_Provincia_Nombre { get; set; }

            [Required]
            public int Solicitud_Estado_Numero { get; set; }
            public string Solicitud_Estado_Descripcion { get; set; }

            [Required]
            public int Linea { get; set; }
            public string Solicitud_Fecha { get; internal set; }
            public string Cantidad_Registros { get; internal set; }
            public string Class_label { get; internal set; }
        }
        public class Parametros_Municipios_Lista
        {
            public int Municipio_Numero { get; set; }
                       
            public string Municipio_Nombre { get; set; }

        }
        public class Parametros_Proveedores_Lista
        {
            public int Proveedor_Numero { get; set; }

            public string Proveedor_Nombre { get; set; }

        }
        public class Parametros_Diagnosticos_Lista
        {
            public string CIE10_Diagnostico_Codigo { get; set; }

            public string CIE10_Diagnostico_Descripcion { get; set; }

        }
        public class Parametros_Solicitudes_Estados_Lista
        {
            public Int32 Solicitud_Estado_Numero { get; set; }

            public string Solicitud_Estado_Descripcion { get; set; }

        }
        public class Parametros_Dispositivos_CIE10_Actualiza
        {
            [Required]
            public int Solicitud_Numero { get; set; }
            
            [StringLength(8, MinimumLength = 2, ErrorMessage = "El Codigo del diagnostico debe contener 8 Caracteres")]
            [DataType(DataType.Text)]
            public string CIE10_Diagnostico_Codigo_1 { get; set; }

            [StringLength(8, MinimumLength = 2, ErrorMessage = "El Codigo del diagnostico debe contener 8 Caracteres")]
            [DataType(DataType.Text)]
            public string CIE10_Diagnostico_Codigo_2 { get; set; }
            [Required]
            public string Registro_Usuario { get; set; }
            public string Mensaje { get; internal set; }
        }

        public class Parametros_Citas_Inserta
        {
            [Required]
            public int Solicitud_Numero { get; set; }

            [Required]
            public int Cita_Numero { get; set; }

            [Required]
            [StringLength(11, MinimumLength = 11, ErrorMessage = "La Fecha de la cita es requerido")]
            [DataType(DataType.DateTime)]
            public DateTime Cita_Fecha { get; set; }

            [Required]
            [StringLength(11, MinimumLength = 11, ErrorMessage = "Debe enviar la hora de inicio de la cita")]
            [DataType(DataType.Time)]
            public DateTime Cita_Hora_Desde { get; set; }

            [Required]
            [StringLength(11, MinimumLength = 11, ErrorMessage = "Debe enviar la hora de fin de la cita")]
            [DataType(DataType.Time)]
            public DateTime Cita_Hora_Hasta { get; set; }

           
            [Required]
            [StringLength(90, MinimumLength = 2, ErrorMessage = "El Usuario de registro es requerido")]
            [DataType(DataType.Text)]
            public string Registro_Usuario { get; set; }
            public string Mensaje { get; internal set; }
        }
    }
}
