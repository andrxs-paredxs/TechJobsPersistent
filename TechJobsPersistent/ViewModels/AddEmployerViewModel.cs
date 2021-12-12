using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TechJobsPersistent.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required(ErrorMessage = "Employer Name is requiered")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Employer's Location is required")]
        public string Location { get; set; }

    }
}
