using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.ViewModels
{
    public class VmMovie
    {
        public Movies Movie { get; set; }
        public List<Movies> Movies { get; set; }
    }
}
