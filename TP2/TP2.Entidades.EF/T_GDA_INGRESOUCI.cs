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
    
    public partial class T_GDA_INGRESOUCI
    {
        public int idIngreso { get; set; }
        public string estPaciente { get; set; }
        public string medSolicitante { get; set; }
        public string gravedad { get; set; }
        public string motDesaprobacion { get; set; }
        public string obsDesaprobacion { get; set; }
        public Nullable<int> idPaciente { get; set; }
    
        public virtual T_GDA_PACIENTE T_GDA_PACIENTE { get; set; }
    }
}
