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
    
    public partial class T_GUQ_INSUMO_TIPOOPERACION
    {
        public int idOperación { get; set; }
        public int idInsumo { get; set; }
        public int cantidad { get; set; }
    
        public virtual T_GUQ_INSUMO T_GUQ_INSUMO { get; set; }
        public virtual T_GUQ_TIPO_OPERACIÓN T_GUQ_TIPO_OPERACIÓN { get; set; }
    }
}
