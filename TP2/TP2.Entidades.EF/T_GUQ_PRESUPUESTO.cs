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
    
    public partial class T_GUQ_PRESUPUESTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_GUQ_PRESUPUESTO()
        {
            this.T_GUQ_CONSOLIDADO_PRESUPUESTO = new HashSet<T_GUQ_CONSOLIDADO_PRESUPUESTO>();
            this.T_GUQ_PRESUPUESTO_PARTIDA = new HashSet<T_GUQ_PRESUPUESTO_PARTIDA>();
        }
    
        public int idPresupuesto { get; set; }
        public int anio { get; set; }
        public int idArea { get; set; }
        public double monto { get; set; }
        public string estado { get; set; }
    
        public virtual T_GUQ_AREA T_GUQ_AREA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GUQ_CONSOLIDADO_PRESUPUESTO> T_GUQ_CONSOLIDADO_PRESUPUESTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GUQ_PRESUPUESTO_PARTIDA> T_GUQ_PRESUPUESTO_PARTIDA { get; set; }
    }
}
