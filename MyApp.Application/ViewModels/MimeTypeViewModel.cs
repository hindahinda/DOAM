using MyApp.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.ViewModels
{
   public class MimeTypeViewModel
    {
        public int MimeTypeID { get; set; }
        public string Mime { get; set; }
        public int AssetTypeID { get; set; } 
        public string TypeLabel { get; set; }
        
    }
}
