using StreamSafari.Model;
using StreamSafari.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSafari.Mapper
{
    public class MovieMapper
    {
       

        public List<MovieViewModel> EnitityToMovieViewModel(List<Movie> p_Movie)
        {
            //MovieViewModel movieViewModel = new MovieViewModel();
            List<MovieViewModel> movies = p_Movie.Select(movie => new MovieViewModel
            {
                Id = movie.Id,
                Name = movie.Name,
                Language = movie.Language
            }).ToList();
            
   
           
          
            return movies;
        }
    }
}
