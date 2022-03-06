using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.ViewModels
{
    public class VmProfile : VmLayout
    {
        public CustomUser CustomUser { get; set; }
    }
}
