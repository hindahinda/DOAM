using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Services
{
   public class TagService
    {
        // GET: Tags
        public static List<MyApp.Infrastructure.DB.Tag> GetTags()
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                var tags = db.Tags;
                return db.Tags.ToList();
            }
        }

        public static Infrastructure.DB.Tag GetTag(int? TagID)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {

                return db.Tags.Find(TagID);
            }
        }
        public static Infrastructure.DB.Tag GetTagID(int? TagID)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                var tag = db.Tags.Find(TagID);
                return tag;
            }
        }
       

        public static void AddTag(Infrastructure.DB.Tag tag)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                db.Tags.Add(tag);
                db.SaveChanges();
            }
        }

        public static void UpdateTag(Infrastructure.DB.Tag tag)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                db.Entry(tag).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteTag(int TagID)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                var tag = db.Tags.Find(TagID);
                db.Tags.Remove(tag);
                db.SaveChanges();
            }
        }
        public static List<Infrastructure.DB.Tag> SearchTagByName(string searchString)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {


                var tag = from s in db.Tags
                             select s;
                if (!String.IsNullOrEmpty(searchString))
                {
                    tag = tag.Where(s => s.Label.ToUpper().Contains(searchString.ToUpper()));
                }

                return tag.ToList();
            }

        }

        public static List<Infrastructure.DB.Tag> SortOrderAsset(string sortOrder)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                var tag = from s in db.Tags
                             select s;

                switch (sortOrder)
                {
                    case "name_desc":
                        tag = tag.OrderByDescending(s => s.Label);
                        break;
                   
                    default:
                        tag = tag.OrderBy(s => s.Label);
                        break;
                }
                return tag.ToList();
            }
        }


    }
}
