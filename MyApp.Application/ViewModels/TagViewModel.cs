using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MyApp.Infrastructure.DB;

namespace MyApp.Application.ViewModels
{
    public class TagViewModel
    {
        public int TagID  { get; set; }
        public string Label { get; set; }
        public Nullable<int> Status { get; set; }  
       
    }
    
}
