using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Infrastructure.DB;

namespace MyApp.Domain.UsersServices
{
  public  class UserRolesService
    {
       
        public static List<AspNetRole> GetAspNetRoles()
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var aspNetRole = db.AspNetRoles;
                return aspNetRole.ToList();
            }
        }

        public static AspNetRole GetAspNetRoleID(string AspNetRoleID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {

                return db.AspNetRoles.Find(AspNetRoleID);
            }
        }


        public static void AddAspNetRole(AspNetRole aspNetRole)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.AspNetRoles.Add(aspNetRole);
                db.SaveChanges();
            }
        }

        public static void UpdateAspNetRole(AspNetRole aspNetRole)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.Entry(aspNetRole).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteAspNetRole(string AspNetRoleID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var aspNetRole = db.AspNetRoles.Find(AspNetRoleID);
                db.AspNetRoles.Remove(aspNetRole);
                db.SaveChanges();
            }
        }
    }
}
