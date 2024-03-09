using StreamSafari.Model;
using StreamSafari.Repository;
using StreamSafari.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.CodeDom.Compiler;

namespace StreamSafari.Service
{
    public class MovieService
    {
        MovieRepository movieRepository = new MovieRepository();

      

        public List<MovieViewModel> ListMovies()
        { 
            List<Movie> movies = movieRepository.ListMovies();
            List<MovieViewModel> movieViewModels = new List<MovieViewModel>();

            foreach (var movie in movies)
            {
                MovieViewModel movieViewModel = new MovieViewModel
                {

                    Id = movie.Id,
                    Name = movie.Name,
                    Language = movie.Language

                };
                movieViewModels.Add(movieViewModel);
            }

            return movieViewModels;
        }

      
        public void BulkUpload(string Url)
        {
            WebClient wc = new WebClient();
            MovieApiViewModel movieApiViewModel = new MovieApiViewModel();
            List<Movie> movies = new List<Movie>();
            int page = 1;

            do
            {
                string newurl = Url + page;
                string jsonString = wc.DownloadString(newurl);
                movieApiViewModel = JsonConvert.DeserializeObject<MovieApiViewModel>(jsonString);

                foreach (var temp in movieApiViewModel.results)
                {
                    Movie movie = new Movie{ 
                        Name = temp.title,
                    Language = temp.original_language
                    };

                        
                movies.Add(movie);
                    
                }
              
                page++;

            } while (page <= movieApiViewModel.total_pages);

            movieRepository.InsertMovies(movies);
        }
      

    }
}
