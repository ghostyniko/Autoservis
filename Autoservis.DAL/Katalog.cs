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
    
    public partial class Katalog
    {
        public decimal Cijena { get; set; }
        public int DobavljacIdDobavljac { get; set; }
        public int RezervniDioIdRezervniDio { get; set; }
    
        public virtual Dobavljac Dobavljac { get; set; }
        public virtual RezervniDio RezervniDio { get; set; }
    }
}
