
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
    
public partial class ObradaVozila
{

    public ObradaVozila()
    {

        this.ZaposleniciObrada = new HashSet<ZaposlenikObrada>();

    }


    public int IdObrada { get; set; }

    public System.DateTime DatumIVrijemeZaprimanja { get; set; }

    public Nullable<System.DateTime> DatumIVrijemePreuzimanja { get; set; }

    public string Opis { get; set; }

    public int VoziloIdVozilo { get; set; }



    public virtual Vozilo Vozilo { get; set; }

    public virtual ICollection<ZaposlenikObrada> ZaposleniciObrada { get; set; }

}

}
