using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Infrastructure.DB;

namespace MyApp.Domain.UsersServices
{
   public class UserClaims
    {
        public static List<AspNetUserClaim> GetAspNetUsersClaims()
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var aspNetUserClaim = db.AspNetUserClaims;
                return aspNetUserClaim.ToList();
            }
        }

        public static AspNetUserClaim GetAspNetUserClaimID(int? AspNetUserClaimID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {

                return db.AspNetUserClaims.Find(AspNetUserClaimID);
            }
        }


        public static void AddAspNetUserClaim(AspNetUserClaim aspNetUserClaim)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.AspNetUserClaims.Add(aspNetUserClaim);
                db.SaveChanges();
            }
        }

        public static void UpdateAspNetUserClaim(AspNetUserClaim aspNetUserClaim)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.Entry(aspNetUserClaim).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteAspNetUserClaim(int AspNetUserClaimID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var aspNetUserClaim = db.AspNetUserClaims.Find(AspNetUserClaimID);
                db.AspNetUserClaims.Remove(aspNetUserClaim);
                db.SaveChanges();
            }
        }
    }
}
