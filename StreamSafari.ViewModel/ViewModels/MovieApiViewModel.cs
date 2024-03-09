using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSafari.ViewModel.ViewModels
{
    public class MovieApiViewModel
    {
        public int page { get; set; }
        public List<MovieInformation> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }

    public class MovieInformation
    {
        public int id { get; set; }
        public string original_language { get; set; }
        public string title { get; set; }
        public string release_date { get; set; }
    }
}


