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
    
    public partial class StavkaNarudzba
    {
        public int Kolicina { get; set; }
        public int RezervniDioIdRezervniDio { get; set; }
        public int IdNarudzba { get; set; }
    
        public virtual RezervniDio RezervniDio { get; set; }
        public virtual Narudzba Narudzba { get; set; }
    }
}
