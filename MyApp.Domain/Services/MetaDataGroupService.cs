using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Infrastructure.DB;

namespace MyApp.Domain.Services
{
    public class MetaDataGroupService
    {
        public static List<MetaDataGroup> GetMetaDatasGroups()
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var metaDataGroup = db.MetaDataGroups;
                return metaDataGroup.ToList();
            }
        }

        public static MetaDataGroup GetMetaDataGroupID(int? MetaDataGroupID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {

                return db.MetaDataGroups.Find(MetaDataGroupID);
            }
        }


        public static void AddMetaDataGroup(MetaDataGroup metaDataGroup)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.MetaDataGroups.Add(metaDataGroup);
                db.SaveChanges();
            }
        }

        public static void UpdateMetaDataGroup(MetaDataGroup metaDataGroup)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.Entry(metaDataGroup).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteMetaDataGroup(int MetaDataGroupID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var metaDataGroup = db.MetaDataGroups.Find(MetaDataGroupID);
                db.MetaDataGroups.Remove(metaDataGroup);
                db.SaveChanges();
            }
        }
    }
}
