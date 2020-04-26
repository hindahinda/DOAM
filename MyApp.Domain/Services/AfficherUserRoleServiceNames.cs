using MyApp.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Services
{
   public class AfficherUserRoleServiceNames
    {
        public static List<SP_AfficherUserRoles_Result> Get()
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                return db.SP_AfficherUserRoles().ToList();
            }
        }
     
    }
}
