using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employer> employers = new List<Employer>();//list of employers
            return View(employers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            return View(addEmployerViewModel);
        }
        //[httppsot] model binding Employer
        [HttpPost]
        [Route("/add")]
        public IActionResult Add(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer newEmployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };

                //TODO: Add this new employer into the DB
                //return View();
                return Redirect("/Employer");
            }

            return View(addEmployerViewModel);
        }

        public IActionResult About(int id)
        {
            return View();
        }
    }
}
