using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyApp.Infrastructure.DB;

namespace MyApp.Domain.UsersServices
{
  public  class UsersService
    {
        public static List<AspNetUser> GetAspNetUsers()
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var aspNetUser = db.AspNetUsers.Include(a=>a.AspNetRoles);
                return aspNetUser.ToList();
            }
        }

        public static AspNetUser GetAspNetUserID(string AspNetUserID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {

                return db.AspNetUsers.Find(AspNetUserID);
            }
        }


        public static void AddAspNetUser(AspNetUser aspNetUser)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.AspNetUsers.Add(aspNetUser);
                db.SaveChanges();
            }
        }

        public static void UpdateAspNetUser(AspNetUser aspNetUser)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.Entry(aspNetUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteAspNetUser(string AspNetUserID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var aspNetUser = db.AspNetUsers.Find(AspNetUserID);
                db.AspNetUsers.Remove(aspNetUser);
                db.SaveChanges();
            }
        }
       
    }
}
