using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using MyApp.Infrastructure.DB;

namespace MyApp.Domain.Services
{
   public class MetaDataService
    {
        public static List<MetaData> GetMetaDatas()
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var metaData = db.MetaDatas.Include(m => m.MetaDataGroup);
                return metaData.ToList();
            }
        }

        public static MetaData GetMetaDataID(int? MetaDataID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {

                return db.MetaDatas.Find(MetaDataID);
            }
        }


        public static void AddMetaData(MetaData metaData)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.MetaDatas.Add(metaData);
                db.SaveChanges();
            }
        }

        public static void UpdateMetaData(MetaData metaData)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.Entry(metaData).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteMetaData(int MetaDataID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var metaData = db.MetaDatas.Find(MetaDataID);
                db.MetaDatas.Remove(metaData);
                db.SaveChanges();
            }
        }

        public static string GetGroupNameMetaData(int id)
        {
            using(DOAMEntities db= new DOAMEntities())
            {
                var groupeName = db.MetaDataGroups.Find(id);
                return groupeName.GroupName;
            }
        }
        public static List<Infrastructure.DB.MetaData> SearchMetaDataByName(string searchString)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {


                var metaData = from s in db.MetaDatas
                             select s;
                if (!String.IsNullOrEmpty(searchString))
                {
                    metaData = metaData.Where(s => s.Title.ToUpper().Contains(searchString.ToUpper()));
                }

                return metaData.ToList();
            }

        }

        public static List<Infrastructure.DB.MetaData> SortOrderMetaData(string sortOrder)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                var metaData = from s in db.MetaDatas
                             select s;

                switch (sortOrder)
                {
                    case "name_desc":
                        metaData = metaData.OrderByDescending(s => s.Title);
                        break;
                    
                    default:
                        metaData = metaData.OrderBy(s => s.Title);
                        break;
                }
                return metaData.ToList();
            }
        }
    }
}
