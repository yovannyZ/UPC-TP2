//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP2.Entidades.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_GUQ_INGRESO_SALIDA_PACIENTE
    {
        public int idRegistro { get; set; }
        public System.DateTime fechaIngreso { get; set; }
        public System.DateTime fechaTraslado { get; set; }
        public string motivo { get; set; }
        public int idSolicitud { get; set; }
    
        public virtual T_GUQ_SOLICITUD_UCI T_GUQ_SOLICITUD_UCI { get; set; }
    }
}
