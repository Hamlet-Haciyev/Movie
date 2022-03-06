using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.ViewModels
{
    public class VmSearch
    {
        public int? page { get; set; }
        public string searchData { get; set; }
        public int? GenreId { get; set; }
        public string SearchMovie { get; set; }
        public string allGenre { get; set; }
        public string TitleOrRating { get; set; }
    }
}
