﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {
        private JobDbContext context;

        public HomeController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        //[HttpGet("/AddJob")]
        public IActionResult AddJob()
        {
            List<Employer> employers = context.Employers.ToList();
            List<Skill> skills = context.Skills.ToList();

            AddJobViewModel addJobViewModel = new AddJobViewModel(employers, skills);

            return View(addJobViewModel);
        }

        [HttpPost]
        [Route("Home/AddJob")]
        [Route("/AddJob")]
        //[Route("Home/AddJob")]
        public IActionResult AddJob( AddJobViewModel addJobViewModel, string[] selectedSkills)
        {
            if (ModelState.IsValid) {
                
                Employer theEmployer = context.Employers.Find(addJobViewModel.EmployerId);
                Job newJob = new Job
                {
                    Name = addJobViewModel.Name,
                    EmployerId = addJobViewModel.EmployerId,
                };

                context.Jobs.Add(newJob);
                context.SaveChanges();

                int newJobId = context.Jobs.Max(p => p.Id);
                
                foreach (string skillId in selectedSkills) {
                    JobSkill jobSkill = new JobSkill
                    {
                        JobId = newJobId,
                        SkillId = Int16.Parse(skillId)
                    };
                    context.JobSkills.Add(jobSkill);
                }

                context.SaveChanges();
                
                return Redirect("/Home/");
            }

            return View(addJobViewModel);
        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs
                .Include(j => j.Employer)
                .Single(j => j.Id == id);

            List<JobSkill> jobSkills = context.JobSkills
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }
    }
}
