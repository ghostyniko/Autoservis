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
    
    public partial class Usluga
    {
        public Usluga()
        {
            this.RacunStavka = new HashSet<RacunStavka>();
        }
    
        public int IdUsluga { get; set; }
        public decimal Cijena { get; set; }
    
        public virtual ICollection<RacunStavka> RacunStavka { get; set; }
    }
}
