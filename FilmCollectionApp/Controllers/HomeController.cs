using FilmCollectionApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

//home controller that routes the model and the views (has http post and get for forms page)
namespace FilmCollectionApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private FilmsContext _context;

        public HomeController(ILogger<HomeController> logger, FilmsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(Films formRes)
        {
            if (ModelState.IsValid)
            {
                _context.Films.Add(formRes);
                _context.SaveChanges();
                return View("Confirmation", formRes);
            }
            return View();
        }
        
        [HttpPost]
        public IActionResult Delete(int FilmID)
        {
            Films film = _context.Films.Where(x => x.FilmID == x.FilmID).FirstOrDefault();

            TempData["Title"] = film.Title;

            _context.Films.Remove(film);
            _context.SaveChanges();
            return View("List");
        }

        [HttpPost]
        public IActionResult EditPost1(int FilmID)
        {
            Films film = _context.Films.Where(x => x.FilmID == x.FilmID).FirstOrDefault();

            ViewBag.Films = film;

            return View("Edit", ViewBag.Films);
        }

        [HttpPost]
        public IActionResult EditPost2(Films formRes)
        {
            if (ModelState.IsValid)
            {
                TempData["Title"] = formRes.Title;

                _context.Films.Update(formRes);
                _context.SaveChanges();

                return View("List");
            }
            else
            {
                ViewBag.Films = formRes;

                return View("Edit", ViewBag.Films);
            }
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(_context.Films);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
