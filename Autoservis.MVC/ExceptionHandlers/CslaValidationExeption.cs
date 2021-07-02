using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Csla.Core;

namespace Autoservis.MVC
{
    public static class ExceptionExtensions
    {
        public static void HandleBusinessException(this BusinessBase businessBase,Exception ex,ControllerContext context)
        {
            var controller = context.Controller as Controller;

            controller.ViewBag.Pogreska = ex.Message;

            if (businessBase.BrokenRulesCollection.Count > 0)
            {
               
                List<string> errors = new List<string>();
                foreach (Csla.Validation.BrokenRule rule in businessBase.BrokenRulesCollection)
                {
                    errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
                    controller.ModelState.AddModelError(rule.Property, rule.Description);
                }
                controller.ViewBag.ErrorsList = errors;
                
            }
            
        }
        
    }
}