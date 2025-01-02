using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Question2_MVC.Models;
using Question2_MVC.Repository;
namespace Question2_MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieRepository mR = new MovieRepository(new MoviesContext());

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                mR.Insert(movie);
                mR.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = mR.GetById(id);
            if (movie == null) return HttpNotFound();
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                mR.Update(movie);
                mR.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Details(int id)
        {
            var movie = mR.GetById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ActionResult Index()
        {
            var movies = mR.GetAll();
            return View(movies);
        }
    }
}