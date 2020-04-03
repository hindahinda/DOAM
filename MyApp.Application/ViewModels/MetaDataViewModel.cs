using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.ViewModels
{
    public class MetaDataViewModel
    {
        public int MetaDataID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MetaDataGroupID { get; set; }
        public string GroupName { get; set; }
    }
}
