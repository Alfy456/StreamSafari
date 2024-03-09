using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSafari.ViewModel.ViewModels
{
    public class JobViewModel
    {
        public int JobId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> CreatedWhen { get; set; }
        public Nullable<System.DateTime> UpdatedWhen { get; set; }
    }
}
