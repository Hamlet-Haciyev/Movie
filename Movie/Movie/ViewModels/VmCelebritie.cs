using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.ViewModels
{
    public class VmCelebritie :VmLayout
    {
        public Cast Cast { get; set; }
        public List<Cast> Casts { get; set; }
        public List<Movies> PlayListMovie { get; set; }
    }
}
