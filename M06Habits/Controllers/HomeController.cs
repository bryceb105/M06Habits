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

        public HomeController(DataContext x)
        {
            myContext = x;
        }

        public IActionResult Index()
        {
            var tasks = myContext.Responses
                .Include(x => x.Category)
                .ToList();
            return View(tasks);
        }

        [HttpGet]
        // get data

        public IActionResult MyApp()
        {
            ViewBag.Categories = myContext.Categories.ToList();

            return View(new ApplicationResponse());
        }

        [HttpPost]
        // post data when valid

        public IActionResult MyApp(ApplicationResponse ar)
        {
                if (ModelState.IsValid)
                {
                    myContext.Add(ar);
                    myContext.SaveChanges();

                    return RedirectToAction ("Index");
                }
                else
                {

                    ViewBag.Categories = myContext.Categories.ToList();
                    return View(ar);
                }

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = myContext.Categories.ToList();

            var task = myContext.Responses.Single(x => x.DataId == id);

            return View("MyApp", task);
        }
        [HttpPost]
        public IActionResult Edit (ApplicationResponse ar)
        {
            myContext.Update(ar);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = myContext.Responses.Single(x => x.DataId == id);
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse response)
        {
            myContext.Responses.Remove(response);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Quadrant()
        {
            return View();
        }
    }
}

