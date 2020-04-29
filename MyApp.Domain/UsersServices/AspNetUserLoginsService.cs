using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Infrastructure.DB;
using System.Data.Entity;

namespace MyApp.Domain.UsersServices
{
    public class AspNetUserLoginsService
    {
        public static List<AspNetUserLogin> GetAspNetUserLogins()
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var aspNetUserLogin = db.AspNetUserLogins.Include(a => a.AspNetUser);
                return aspNetUserLogin.ToList();
            }
        }

        public static AspNetUserLogin GetAspNetUserLoginID(string AspNetUserLoginID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {

                return db.AspNetUserLogins.Find(AspNetUserLoginID);
            }
        }


        public static void AddAspNetUserLogin(AspNetUserLogin aspNetUserLogin)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.AspNetUserLogins.Add(aspNetUserLogin);
                db.SaveChanges();
            }
        }

        public static void UpdateAspNetUserLogin(AspNetUserLogin aspNetUserLogin)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.Entry(aspNetUserLogin).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteAspNetUserLogin(string AspNetUserLoginID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var aspNetUserLogin = db.AspNetUserLogins.Find(AspNetUserLoginID);
                db.AspNetUserLogins.Remove(aspNetUserLogin);
                db.SaveChanges();
            }
        }
    }
}
