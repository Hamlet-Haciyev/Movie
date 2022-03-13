using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.ViewModels
{
    public class VmMovieAdminAjaxDetail
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public Movies Movie { get; set; }
    }
}
