using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Autoservis.BLL
{
    public enum Status
    {

        [Description("Ponuda klijenta")]
        PonudaKlijenta = 0,

        [Description("Ponuda autoservisa")]
        PonudaAutoservisa = 1,

        [Description("Prihvatio klijent")]
        PrihvatioKlijent = 2,

        [Description("Prihvatio autoservis")]
        PrihvatioAutoservis =3,

        [Description("Kreirano")]
        Kreirano =4,

        [Description("Poništeno")]
        Ponisteno =5


         
    }

    public class StatusHelper
    {
        public static Status Get(int i)
        {
            switch (i)
            {
                case 0:
                    return Status.PonudaKlijenta;
                case 1:
                    return Status.PonudaAutoservisa;
                case 2:
                    return Status.PrihvatioKlijent;
                case 3:
                    return Status.PrihvatioAutoservis;
                case 4:
                    return Status.Kreirano;
                default:
                    return Status.Ponisteno;

            }
        }

        public static string GetString(Status value)
        {

            return
        value
            .GetType()
            .GetMember(value.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<DescriptionAttribute>()
            ?.Description
        ?? value.ToString();
        }
    }

   
}
