//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Autoservis.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vozilo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vozilo()
        {
            this.ObradaVozila = new HashSet<ObradaVozila>();
        }
    
        public int IdVozilo { get; set; }
        public string Marka { get; set; }
        public string Tip { get; set; }
        public short GodinaProizvodnje { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObradaVozila> ObradaVozila { get; set; }
        public virtual Klijent Klijent { get; set; }
    }
}
