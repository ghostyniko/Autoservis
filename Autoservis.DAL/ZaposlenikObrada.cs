
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
    
public partial class ZaposlenikObrada
{

    public int ZaposlenikIdZaposlenik { get; set; }

    public int ObradaVozilaIdObrada { get; set; }

    public int BrojPopravaka { get; set; }



    public virtual Zaposlenik Zaposlenik { get; set; }

    public virtual ObradaVozila ObradaVozila { get; set; }

}

}
