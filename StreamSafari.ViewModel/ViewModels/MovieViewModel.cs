using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSafari.ViewModel.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public Nullable<int> MovieId { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public string Image { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> createdBy { get; set; }
    }

   
}
