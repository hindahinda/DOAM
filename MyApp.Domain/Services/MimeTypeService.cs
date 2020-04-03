using MyApp.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Services
{
    //MimeTypes
   public class MimeTypeService
    { 
        public static List<MyApp.Infrastructure.DB.MimeType> GetMimeTypes()
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {

                IQueryable<MimeType> queryable = db.MimeTypes.Include(m => m.AssetType); 
                var mimeTypes = queryable;
                return (mimeTypes.ToList());
            }
        }
        public static MimeType GetMimeTypeID(int? MimeTypeID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {

                return db.MimeTypes.Find(MimeTypeID);
            }
        }


        public static void AddMimeType(MimeType mimeType)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.MimeTypes.Add(mimeType);
                db.SaveChanges();
            }
        }

        public static void UpdateMimeType(MimeType mimeType)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                db.Entry(mimeType).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteMimeType(int MimeTypeID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {
                var mimeType = db.MimeTypes.Find(MimeTypeID);
                db.MimeTypes.Remove(mimeType);    
                db.SaveChanges();
            }
        }
        public static List<Infrastructure.DB.MimeType> SearchMimeTypeByName(string searchString)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {


                var mime = from s in db.MimeTypes
                          select s;
                if (!String.IsNullOrEmpty(searchString))
                {
                    mime = mime.Where(s => s.Mime.ToUpper().Contains(searchString.ToUpper()));
                }

                return mime.ToList();
            }

        }

        public static string GetMimeTypeName(int? MimeTypeID)
        {
            using (DOAMEntities db = new DOAMEntities())
            {

                var mimeType = db.MimeTypes.Find(MimeTypeID);
                return mimeType.Mime;

            }
        }
        public static List<Infrastructure.DB.MimeType> SortOrderMimeType(string sortOrder)
        {
            using (Infrastructure.DB.DOAMEntities db = new Infrastructure.DB.DOAMEntities())
            {
                var mime = from s in db.MimeTypes
                           select s;

                switch (sortOrder)
                {
                    case "name_desc":
                        mime = mime.OrderByDescending(s => s.Mime);
                        break;

                    default:
                        mime = mime.OrderBy(s => s.Mime);
                        break;
                }
                return mime.ToList();
            }
        }   
    }
}
