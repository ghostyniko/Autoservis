//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Autoservis.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ZahtjevZaNarudzbomStavka
    {
        public int ZahtjevZaNarudzbomId { get; set; }
        public int ZahtjevanaKolicina { get; set; }
        public int NarucenaKolicina { get; set; }
        public int RezervniDioIdRezervniDio { get; set; }
    
        public virtual ZahtjevZaNarudzbom ZahtjevZaNarudzbom { get; set; }
        public virtual RezervniDio RezervniDio { get; set; }
    }
}
