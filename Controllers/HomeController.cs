using HiltonFilmCollection2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HiltonFilmCollection2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private FilmContext context { get; set; }
        public HomeController(ILogger<HomeController> logger, FilmContext con)
        {
            _logger = logger;
            context = con;
        }



        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FilmSubmission()
        {
            return View();
        }
        
        //Adds item to database only if input is valid
        [HttpPost]
        public IActionResult FilmSubmission(FilmItem film)
        {
            if (ModelState.IsValid)
            {
                context.Films.Add(film);
                context.SaveChanges();
                return View("Confirmation", film);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult FilmCollection()
        {
            return View(context.Films);
        }

        //Deletes item in database when delete button is selected
        [HttpPost]
        public IActionResult FilmCollection(int filmid)
        {
            foreach (FilmItem film in context.Films.Where(f => f.FilmId == filmid)) {
                context.Films.Remove(film);
                context.SaveChanges();
            }
            return View(context.Films);
        }
        
        //Passes film info via viewbag to display film info and allow it to be updated in database
        [HttpGet]
        public IActionResult UpdateFilm(int filmid)
        {

            FilmItem film = context.Films.Where(f => f.FilmId == filmid).FirstOrDefault();
            ViewBag.film = film;
            return View();
        }
        
        //Updates item in database only if input is valid
        [HttpPost]
        public IActionResult UpdateFilm(FilmItem film, int filmid)
        {
            if (ModelState.IsValid)
            {
                context.Films.Where(f => f.FilmId == filmid).FirstOrDefault().Title = film.Title;
                context.Films.Where(f => f.FilmId == filmid).FirstOrDefault().Year = film.Year;
                context.Films.Where(f => f.FilmId == filmid).FirstOrDefault().Director = film.Director;
                context.Films.Where(f => f.FilmId == filmid).FirstOrDefault().Rating = film.Rating;
                context.Films.Where(f => f.FilmId == filmid).FirstOrDefault().Edited = film.Edited;
                context.Films.Where(f => f.FilmId == filmid).FirstOrDefault().LentTo = film.LentTo;
                context.Films.Where(f => f.FilmId == filmid).FirstOrDefault().Notes = film.Notes;
                context.SaveChanges();
                return View("UpdateConfirm", film);
            }
            else
            {
                return View();
            }

        }

        public IActionResult MyPodcasts()
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
    }
}
