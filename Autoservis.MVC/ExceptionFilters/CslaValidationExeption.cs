using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autoservis.MVC.ExceptionFilters
{
    public class CslaValidationExeption : IExceptionFilter
    {
        
        public void OnException(ExceptionContext filterContext)
        {
           /* var exType = filterContext.Exception.GetType();*/

            if (filterContext.Exception is Csla.Validation.ValidationException)
            {
               

            }
            throw new NotImplementedException();
        }
    }
}