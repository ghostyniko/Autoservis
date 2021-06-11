using AutoservisBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autoservis.MVC.Controllers
{
    public class MjestoController : Controller
    {
        [HttpGet]
        // GET: Mjesto
        public ActionResult Create()
        {
            return View(Mjesto.New());
        }

        [HttpPost]
        public ActionResult Create(string NazivMjesta, int PostanskiBroj)
        {
            Mjesto mjesto = Mjesto.New();
           
            
                mjesto.NazivMjesta = NazivMjesta;
                mjesto.PostanskiBroj = PostanskiBroj;
              
                mjesto = mjesto.Save();
                AutoservisBLL.MjestoList.InvalidateCache();

            return RedirectToAction("Index", "Home");

            //  return RedirectToAction("Index","Home",null);

            /*    catch (Csla.Validation.ValidationException ex)
                {
                    ViewBag.Pogreska = ex.Message;
                    if (osoba.BrokenRulesCollection.Count > 0)
                    {
                        List<string> errors = new List<string>();
                        foreach (Csla.Validation.BrokenRule rule in osoba.BrokenRulesCollection)
                        {
                            errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
                            ModelState.AddModelError(rule.Property, rule.Description);
                        }
                        ViewBag.ErrorsList = errors;
                    }
                    return View(osoba);
                }
                catch (Csla.DataPortalException ex)
                {
                    ViewBag.Pogreska = ex.BusinessException.Message;
                    return View(osoba);
                }
                catch (Exception ex)
                {
                    ViewBag.Pogreska = ex.Message;
                    return View(osoba);
                }*/

        }
    }
}