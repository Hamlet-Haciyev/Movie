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
        public List<Tag> Tags { get; set; }
        public List<BlogComment> BlogComments { get; set; }
        public BlogComment BlogComment { get; set; }
        public List<BlogComment> ReplyComments { get; set; }
        public VmSearch VmSearch { get; set; }
        public List<Blog> PopularBlogs { get; set; }
    }
}
