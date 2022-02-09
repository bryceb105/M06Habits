using M06Habits.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace M06Habits.Controllers
{
    public class HomeController : Controller
    {
        private DataContext myContext { get; set; }

        public HomeController(DataContext someName)
        {
            myContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        // get data

        public IActionResult MyApp()
        {
            ViewBag.Categories = myContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        // post data when valid

        public IActionResult MyApp(ApplicationResponse ar)
        {
                if (ModelState.IsValid)
                {
                    myContext.Add(ar);
                    myContext.SaveChanges();

                    return View("confirmation", ar);
                }
                else
                {

                    ViewBag.Categories = myContext.Categories.ToList();
                    return View(ar);
                }

        }

        //List View
        public IActionResult List()
        {
            var applications = myContext.Responses
                .Include(x => x.category)
                .ToList()

                .ToList();

            return View(applications); // return list of applications
        }
    }
}
