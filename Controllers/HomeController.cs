using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Fellows.Models;

namespace Mission06_Fellows.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public MovieContext _context;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        public IActionResult SubmitAMovie()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View();
        }

        [HttpPost]
        public IActionResult SubmitForm(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("SubmitAMovie");
        }

        public IActionResult ViewCollection()
        {
            var movies = _context.Movies
       .Join(
           _context.Categories,
           movie => movie.CategoryId,
           category => category.CategoryId,
           (movie, category) => new MovieViewModel
           {
               MovieId = movie.MovieId,
               Title = movie.Title,
               Year = movie.Year,
               Director = movie.Director,
               CategoryName = category.CategoryName,
               Rating = movie.Rating,
               Edited = movie.Edited,
               CopiedToPlex = movie.CopiedToPlex,
               LentTo = movie.LentTo,
               Notes = movie.Notes
           })
       .ToList();

            return View(movies);
        }

      

        public IActionResult Delete(int id)
        {
            var movie = _context.Movies
                .Where(x => x.MovieId == id)
                .FirstOrDefault();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("ViewCollection");
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            
            _context.Update(movie);
            _context.SaveChanges();

            var movies = _context.Movies
       .Join(
           _context.Categories,
           movie => movie.CategoryId,
           category => category.CategoryId,
           (movie, category) => new MovieViewModel
           {
               MovieId = movie.MovieId,
               Title = movie.Title,
               Year = movie.Year,
               Director = movie.Director,
               CategoryName = category.CategoryName,
               Rating = movie.Rating,
               Edited = movie.Edited,
               CopiedToPlex = movie.CopiedToPlex,
               LentTo = movie.LentTo,
               Notes = movie.Notes
           })
       .ToList();

            return View("ViewCollection", movies);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies
                .Where(x => x.MovieId == id)
                .FirstOrDefault();
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View(movie);
        }
    }


}
