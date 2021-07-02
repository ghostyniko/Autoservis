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
    public class SudionikObrade:BusinessBase<SudionikObrade>
    {
       
        #region Constructors
        private SudionikObrade()
        {
        }
        #endregion

        #region  Properties
        private static PropertyInfo<int> IdZaposlenikaProperty =
          RegisterProperty(new PropertyInfo<int>(Reflector.GetPropertyName<SudionikObrade>(x => x.IdZaposlenika)));
        public int IdZaposlenika
        {
            get { return GetProperty(IdZaposlenikaProperty); }
        }

        private static PropertyInfo<string> ImeZaposlenikaProperty =
          RegisterProperty(new PropertyInfo<string>(Reflector.GetPropertyName<SudionikObrade>(x => x.ImeZaposlenika)));
        public string ImeZaposlenika
        {
            get { return GetProperty(ImeZaposlenikaProperty); }
        }

        private static PropertyInfo<string> PrezimeZaposlenikaProperty =
          RegisterProperty(new PropertyInfo<string>(Reflector.GetPropertyName<SudionikObrade>(x => x.PrezimeZaposlenika)));
        public string PrezimeZaposlenika
        {
            get { return GetProperty(PrezimeZaposlenikaProperty); }
        }

        private static PropertyInfo<int> BrojPopravakaProperty =
         RegisterProperty(new PropertyInfo<int>(Reflector.GetPropertyName<SudionikObrade>(x => x.BrojPopravaka)));
        public int BrojPopravaka
        {
            get { return GetProperty(BrojPopravakaProperty); }
            set { SetProperty(BrojPopravakaProperty, value); }
        }

        #region Calculated Properties
        public string PunoImeZaposlenika
        {
            get { return PrezimeZaposlenika + ", " + ImeZaposlenika; }
        }
        #endregion

        #region Business Methods
        public Zaposlenik GetZaposlenik()
        {
            return Zaposlenik.Get(GetProperty(IdZaposlenikaProperty));
        }
        #endregion

        #region  Factory Methods
        internal static SudionikObrade New(int idZaposlenika)
        {
            return DataPortal.CreateChild<SudionikObrade>(idZaposlenika);
        }
        #endregion

        internal static SudionikObrade Load(DAL.ZaposlenikObrada data)
        {
            return DataPortal.FetchChild<SudionikObrade>(data);
        }
        #endregion

        #region  Validation Rules
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.IntegerMinValue, new CommonRules.IntegerMinValueRuleArgs(BrojPopravakaProperty, 1));

        }
        #endregion

        #region  Data Access
        protected override void Child_Create()
        {
            LoadProperty(BrojPopravakaProperty,1);
        }

        private void Child_Create(int idZaposlenika)
        {
            var zap = Zaposlenik.Get(idZaposlenika);
            LoadProperty(IdZaposlenikaProperty, zap.IdZaposlenika);

            LoadProperty(PrezimeZaposlenikaProperty, zap.PrezimeZaposlenika);
            LoadProperty(ImeZaposlenikaProperty, zap.ImeZaposlenika);
            LoadProperty(BrojPopravakaProperty, ObradaZaduzenja.GetBrojPopravaka());
      
        }

        private void Child_Fetch(DAL.ZaposlenikObrada data)
        {
            //var zap = Zaposlenik.Get(data.ZaposlenikIdZaposlenik);
            LoadProperty(IdZaposlenikaProperty, data.ZaposlenikIdZaposlenik);
            LoadProperty(PrezimeZaposlenikaProperty, data.Zaposlenik.Prezime);
            LoadProperty(ImeZaposlenikaProperty, data.Zaposlenik.Ime);
            LoadProperty(BrojPopravakaProperty, data.BrojPopravaka);
        }

        private void Child_Insert(ObradaVozila obrada)
        {
            ObradaZaduzenja.DodajZaduzenje(obrada.IdObrade, ReadProperty(IdZaposlenikaProperty));
        }

        private void Child_Update(ObradaVozila obrada)
        {
            ObradaZaduzenja.PromijeniBrojPopravaka(obrada.IdObrade, ReadProperty(IdZaposlenikaProperty), ReadProperty(BrojPopravakaProperty));
        }

        private void Child_DeleteSelf(ObradaVozila obrada)
        {
            ObradaZaduzenja.UkloniZaduzenje(obrada.IdObrade, ReadProperty(IdZaposlenikaProperty));
        }
        #endregion
    }
}
