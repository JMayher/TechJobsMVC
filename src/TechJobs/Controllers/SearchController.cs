using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        static private List<Dictionary<string, string>> searchResults = new List<Dictionary<string, string>>();
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            ViewBag.jobs = searchResults;
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            
            if (searchType.Equals("all"))
            {
                searchResults = JobData.FindByValue(searchTerm);
                
            }
            else
            {
                searchResults = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = searchResults;
                
            }
            return Redirect("/Search/Index");
        }

    }
}
