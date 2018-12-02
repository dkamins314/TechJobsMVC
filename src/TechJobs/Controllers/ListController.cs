using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class ListController : Controller
    {
        internal static Dictionary<string, string> columnChoices = new Dictionary<string, string>();

        // This is a "static constructor" which can be used
        // to initialize static members of a class
        static ListController() 
        {
            
            columnChoices.Add("core competency", "Skill");
            columnChoices.Add("employer", "Employer");
            columnChoices.Add("location", "Location");
            columnChoices.Add("position type", "Position Type");
            columnChoices.Add("all", "All");
        }

        public IActionResult Index()
        {//displays job fields
            ViewBag.columns = columnChoices;//all fields
            return View();
        }

        public IActionResult Values(string column)
        {
            if (column.Equals("all"))//if request is to get all jobs
            {
                IEnumerable<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.title =  "All Jobs";
                ViewBag.jobs = jobs;
                return View("Jobs");
            }
            else // if request is to get jobs based on user input for a certain field
            {
                IEnumerable<string> items = JobData.FindAll(column);//A list called "items" will contain
                                                             // all matching properties found in that column
                ViewBag.title =  "All " + columnChoices[column] + " Values";
                ViewBag.column = column;//will pass field(column)title to display 
                ViewBag.items = items;//will pass property(row) value to display 
                return View();
            }
        }

        public IActionResult Jobs(string column, string value)
        {
            IEnumerable<Dictionary<String, String>> jobs = JobData.FindByColumnAndValue(column, value);
            //dictionary "jobs" will hold job fields(columns) as keys and properties as values
            ViewBag.title = "Jobs with " + columnChoices[column] + ": " + value;
            //pass title  to be displayed "Jobs with (field): job value
            ViewBag.jobs = jobs; //pass job value to display 

            return View("Jobs");
        }
    }
}
