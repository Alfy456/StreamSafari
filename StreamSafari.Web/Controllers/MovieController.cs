using StreamSafari.Service;
using StreamSafari.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace StreamSafari.Web.Controllers
{
    public class MovieController : Controller
    {
        MovieService movieService = new MovieService();
        // GET: Movie
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page )
        {
            ViewBag.CurrentSort = sortOrder;
            IEnumerable<MovieViewModel> movieList = movieService.ListMovies();
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.LanguageSortParm = String.IsNullOrEmpty(sortOrder) ? "language_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            if (!String.IsNullOrEmpty(searchString))
             {
                movieList = movieService.searchMovie(searchString);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    movieList = movieList.OrderByDescending(m => m.Name);
                    break;
                case "language_desc":
                    movieList = movieList.OrderByDescending(m => m.Language);
                    break;
                case "date_desc":
                  
                    break;
                default:
                    movieList = movieList.OrderByDescending(m => m.Name);
                    break;
            }
            int pageSize = 20;
            int pageNumber = (page ?? 1);
           
            return View(movieList.ToPagedList(pageNumber,pageSize));
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