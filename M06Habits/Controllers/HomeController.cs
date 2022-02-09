using M06Habits.Models;
using Microsoft.AspNetCore.Mvc;
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
        private ContextBoundObject _context { get; set; }
        public HomeController(Context x)
        {
            _context = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddTask(ApplicationResponse response)
        {
            //check validity of inputs
            if (ModelState.IsValid)
            {
                _context.Add(response);
                _context.SaveChanges();
                return View("Index");
            }
            //show errors if not valid
            else
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View(response);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _context.Categories.ToList();

            var task = _context.responses.Single(x => x.id == id);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(ApplicationResponse response)
        {
            _context.Update(response);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = _context.responses.Single(x => x.id == id);
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse response)
        {
            _context.responses.Remove(response);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
