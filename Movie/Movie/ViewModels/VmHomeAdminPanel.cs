using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.ViewModels
{
    public class VmHomeAdminPanel
    {
        public List<CustomUser> CustomUsers { get; set; }
        public List<Movies> TopMovies { get; set; }
        public List<Movies> LastestMovies { get; set; }
    }
}
