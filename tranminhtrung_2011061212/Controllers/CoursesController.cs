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
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel()
            {
                Categories = _context.Categories.ToList()
            };

            return View(viewModel);
        }
        // GET: Courses
        public ActionResult Index()
        {
            return View();
        }
    }
}