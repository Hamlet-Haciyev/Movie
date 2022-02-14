using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.ViewModels
{
    public class VmBlog : VmLayout
    {
        public Blog Blog { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
