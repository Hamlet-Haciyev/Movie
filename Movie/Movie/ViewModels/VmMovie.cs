using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.ViewModels
{
    public class VmMovie: VmLayout
    {
        public Movies Movie { get; set; }
        public List<Movies> Movies { get; set; }
        public List<MovieComment> MovieComments { get; set; }
        public MovieComment MovieComment { get; set; }
        public List<int> GenreIds { get; set; }
        public List<Movies> RelatedMovies { get; set; }
    }
}
