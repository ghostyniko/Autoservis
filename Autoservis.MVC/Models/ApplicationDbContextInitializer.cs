using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Autoservis.MVC.Models
{
    public  static class ApplicationDbContextInitializer
    {

        public static void Initialize(ApplicationDbContext context)
        {
            var roles = context.Roles;
            if (roles.Count() > 0)
            {
                return;
            }
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            {
                Name = "Customer"
            });
            context.SaveChanges();
        }
    }
}