using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpPost]
        public IActionResult SubmitForm(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return View("SubmitAMovie");
        }
    }
}
