using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tranminhtrung_2011061212.Models;
using tranminhtrung_2011061212.ViewModels;

namespace tranminhtrung_2011061212.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel()
            {
                Categories = _context.Categories.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if(!ModelState.IsValid) {
            
                viewModel.Categories = _context.Categories.ToList();
                return View("Create", viewModel);
            }
            var courses = new Course()
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place,
            };
            _context.Courses.Add(courses);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        // GET: Courses
        public ActionResult Index()
        {
            return View();
        }
    }
}