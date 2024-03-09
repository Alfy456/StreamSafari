using StreamSafari.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Extensions;

namespace StreamSafari.Repository
{
    public class MovieRepository
    {
        StreamSafariEntities db = new StreamSafariEntities();


        public List<Movie> ListMovies()
        {
            List<Movie> movies = db.Movies.ToList();
            return movies;
        }
       
        public void InsertMovies(List<Movie> movies)
        {
            using (var context = new StreamSafariEntities())
            {
                context.BulkInsert(movies);
            }
        }

    }
}
