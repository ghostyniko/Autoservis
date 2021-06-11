using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Csla;
using Csla.Validation;

namespace Autoservis
{
    [Serializable()]
    public class ObradaSudionici :BusinessBase<ObradaSudionici>
    {

            #region Constructors
            private ObradaSudionici()
            {
            }
            #endregion

            #region  Properties
            private static PropertyInfo<int> IdObradeProperty =
              RegisterProperty(new PropertyInfo<int>(Reflector.GetPropertyName<ObradaSudionici>(x => x.IdObrade)));
            public int IdObrade
            {
                get { return GetProperty(IdObradeProperty); }
            }

            private static PropertyInfo<string> NazivObradeProperty =
              RegisterProperty(new PropertyInfo<string>(Reflector.GetPropertyName<ObradaSudionici>(x => x.NazivObrade)));
            public string NazivObrade
            {
                get { return GetProperty(NazivObradeProperty); }
            }

        private static PropertyInfo<int> BrojPopravakaProperty =
      RegisterProperty(new PropertyInfo<int>(Reflector.GetPropertyName<ObradaSudionici>(x => x.BrojPopravaka)));
        public int BrojPopravaka
        {
            get { return GetProperty(BrojPopravakaProperty); }
            set { SetProperty(BrojPopravakaProperty, value); }
        }

        #region Business Methods
        public ObradaVozila GetObrada()
            {
                return ObradaVozila.Get(IdObrade);
            }
            #endregion

            #region  Factory Methods
            internal static ObradaSudionici New(int idObrade)
            {
                return DataPortal.CreateChild<ObradaSudionici>(idObrade);
            }
            #endregion

            internal static ObradaSudionici Load(DAL.ZaposlenikObrada data)
            {
                return DataPortal.FetchChild<ObradaSudionici>(data);
            }
        #endregion

        #region  Validation Rules
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.IntegerMinValue, new CommonRules.IntegerMinValueRuleArgs(BrojPopravakaProperty, 1));

        }
        #endregion

        #region  Data Access
        private void Child_Create(int idObrade)
            {
                var obr = ObradaVozila.Get(idObrade);

                LoadProperty(IdObradeProperty, obr.IdObrade);
                LoadProperty(NazivObradeProperty, obr.Opis);
            LoadProperty(BrojPopravakaProperty, ObradaZaduzenja.GetBrojPopravaka());
            }

            private void Child_Fetch(DAL.ZaposlenikObrada data)
            {
            string nazivObrade = data.ObradaVozila.Vozilo.Marka 
                + data.ObradaVozila.Vozilo.Tip + ", " 
                + data.ObradaVozila.DatumIVrijemeZaprimanja;

            LoadProperty(IdObradeProperty, data.ObradaVozilaIdObrada);
            LoadProperty(NazivObradeProperty, nazivObrade);
            LoadProperty(BrojPopravakaProperty, data.BrojPopravaka);
        }

            private void Child_Insert(Zaposlenik resource)
            {
                ObradaZaduzenja.DodajZaduzenje(IdObrade, resource.IdZaposlenika);
             }

        private void Child_Update(Zaposlenik resource)
        {
            ObradaZaduzenja.PromijeniBrojPopravaka(ReadProperty(IdObradeProperty), resource.IdZaposlenika, ReadProperty(BrojPopravakaProperty));
        }

        private void Child_DeleteSelf(Zaposlenik resource)
            {
                ObradaZaduzenja.UkloniZaduzenje(ReadProperty(IdObradeProperty),resource.IdZaposlenika);
            }
            #endregion
        
    }
}
