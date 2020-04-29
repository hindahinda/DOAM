using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MyApp.Infrastructure.DB;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Application.ViewModels
{
    public class TagViewModel
    {
        public int TagID  { get; set; }
        [Required(ErrorMessage = "Please enter the Label.")]
        [StringLength(49, ErrorMessage = "The label must be less than {0} characters. ")]
        public string Label { get; set; }
        public Nullable<int> Status { get; set; }  
       
    }
    
}
