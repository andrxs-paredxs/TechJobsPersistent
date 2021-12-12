using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        [Required(ErrorMessage = "Job Position is required!")]
        public string Name { get; set; }

        public Employer Type {get; set; }

        public List<SelectListItem> Employers { get; set; } = new List<SelectListItem>
        {
            //TODO: Work with the DB to get a list 0f the employer's name and Id
            //select id, name from Employer this should return a List
            new SelectListItem("Select Employer","0"),
            new SelectListItem("Andres Test", "1"),
            new SelectListItem("Sandra Test", "2"),
            new SelectListItem("Ed Test", "3")
        };
    }
}
