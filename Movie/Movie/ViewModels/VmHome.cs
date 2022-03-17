using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.ViewModels
{
    public class VmHome : VmLayout
    {
    
        public List<Movies> Movies { get; set; }
        public List<Cast> Casts { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Movies> MoviesDescOrder { get; set; }
        public List<string> BgColors { get; set; }
        public List<Blog> Blogs { get; set; }
        public Blog Blog { get; set; }
        public VmSearch VmSearch { get; set; }
        public List<MovieComment> MovieComments { get; set; }
        public List<Cast> SpotlightCelebritie { get; set; }
    }
}
