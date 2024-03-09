using StreamSafari.Service;
using StreamSafari.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StreamSafari.Web.Controllers
{
    public class MovieController : Controller
    {
        MovieService movieService = new MovieService();
        // GET: Movie
        public ActionResult Index()
        {
            List<MovieViewModel> movies = movieService.ListMovies();
            return View(movies);
        }

        public ActionResult CreateMovie()
        {
            return View();
        }

        public void BulkUpload()
        {
            var Url = "https://api.themoviedb.org/3/discover/movie";
            var ApiKey = "c8656808145423583f9da1afd7d1e967";
            var Language = "en-US";
            var OriginalLanguage = "ml";
            var SortBy = "release_date.desc";

            var webURL = Url + "?" + "api_key" + "=" + ApiKey + "&" + "language" + "=" + Language + "&" + "with_original_language" + "=" + OriginalLanguage + "&" + "sort_by" + "=" + SortBy + "&" + "page" + "=" ;
            movieService.BulkUpload(webURL);
          

        } 

       
    }
}