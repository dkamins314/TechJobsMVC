using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices; //columns passed to ViewBag are 
            //columns -ie fields from the column choices in the ListController
            ViewBag.title = "Search"; //title to be displayed is "Search"
            return View(); //Search: with fields for searching will be displayed
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices; //all columns/fields are passed to ViewBag
             
            ViewBag.title = "Search";
            if (string.IsNullOrEmpty(searchTerm))
                          {
                           return View("Index");
                          }
                          
                          if (searchType.Equals("all"))
                          {
                           ViewBag.jobs = JobData.FindByValue(searchTerm);//JobData will be searched with
                           //FindByValue method based on searchTerm -results will be passed into"jobs" variable in Viewbag
                             
                           return View("Index");
                          }
                          else
                          {
                              ViewBag.jobs = JobData.FindByColumnAndValue(searchType,searchTerm);
                           
                           return View("Index");
                          }

            // TODO #1 - Create a Results action method to process 
            // search request and display results

        }
    }
}
