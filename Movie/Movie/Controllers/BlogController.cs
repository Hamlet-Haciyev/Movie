using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Data;

using Movie.Models;
using Movie.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public BlogController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index(VmSearch vmSearch)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!User.IsInRole("User"))
                {
                    return RedirectToAction("Logout", "Account");
                }
            }

            if (vmSearch == null || vmSearch.page == null)
            {
                vmSearch.page = 1;
            }

            Setting setting = _appDbContext.Settings.FirstOrDefault();
            List<Blog> blogs = _appDbContext.Blogs.Where(b =>(vmSearch.searchData != null ? b.Title.Contains(vmSearch.searchData) : true))
                                                .Include(c => c.BlogToTags).ThenInclude(bt => bt.Tag)
                                                .ToList();
            List<VmPopularBlog> vmPopularBlogs = _appDbContext.BlogComments
                                                                    .GroupBy(bc => bc.BlogId)
                                                                    .Select(b => new VmPopularBlog { BlogId = b.Key,Count=b.Count()})
                                                                    .OrderByDescending(b=>b.Count)
                                                                    .Take(3)
                                                                    .ToList();
            List<Blog> popularBlogs = new List<Blog>();
            foreach (var item in vmPopularBlogs)
            {
                Blog popBlog = _appDbContext.Blogs.Where(b => b.Id == item.BlogId)
                                                                    .FirstOrDefault();
                popularBlogs.Add(popBlog);
            }

            double itemCount = 5;

            int pageCount = (int)Math.Ceiling(Convert.ToDecimal(blogs.Count / itemCount));

            ViewBag.PageCount = pageCount;
            ViewBag.PageField = vmSearch.page;

            VmBlog vmBlog = new VmBlog()
            {
                Setting = setting,
                Blogs = blogs.Skip(((int)vmSearch.page - 1) * (int)itemCount).Take((int)itemCount).ToList(),
                VmSearch = vmSearch,
                PopularBlogs = popularBlogs
            };
            ViewBag.Page = "Blog";

            return View(vmBlog);
        }
        public IActionResult Detail(int? id,BlogComment blogComment)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!User.IsInRole("User"))
                {
                    return RedirectToAction("Logout", "Account");
                }
            }

            Blog blog = null;
            List<Tag> tags = null;
            List<BlogComment> blogComments = null;
            List<BlogComment> replyComments = null;

            if (id != null)
            {
                blog = _appDbContext.Blogs
                                           .Include(c => c.BlogToTags).ThenInclude(bt => bt.Tag)
                                           .FirstOrDefault(b => b.Id == id);
                tags = _appDbContext.Tags.ToList();
                blogComments = _appDbContext.BlogComments.Where(bc => bc.BlogId == id).ToList();
                replyComments = _appDbContext.BlogComments.Where(bc => bc.BlogId == id && bc.ParentCommentId != null).ToList();
            }
            else
            {
                return RedirectToAction("Index", "Error", new { area = "admin" });
            }

            Setting setting = _appDbContext.Settings.FirstOrDefault();

            List<VmPopularBlog> vmPopularBlogs = _appDbContext.BlogComments
                                                                    .GroupBy(bc => bc.BlogId)
                                                                    .Select(b => new VmPopularBlog { BlogId = b.Key, Count = b.Count() })
                                                                    .OrderByDescending(b => b.Count)
                                                                    .Take(3)
                                                                    .ToList();
            List<Blog> popularBlogs = new List<Blog>();
            foreach (var item in vmPopularBlogs)
            {
                Blog popBlog = _appDbContext.Blogs.Where(b => b.Id == item.BlogId)
                                                                    .FirstOrDefault();
                popularBlogs.Add(popBlog);
            }

            VmBlog vmBlog = new VmBlog()
            {
                Setting = setting,
                Blog = blog,
                Tags = tags,
                BlogComments = blogComments,
                ReplyComments = replyComments,
                BlogComment =blogComment,
                PopularBlogs = popularBlogs
            };
            ViewBag.Page = "Blog";

            return View(vmBlog);
        }
        public IActionResult Comment(BlogComment blogComment)
        {

            if (ModelState.IsValid)
            {
                blogComment.CreatedDate = DateTime.Now;
                _appDbContext.BlogComments.Add(blogComment);
                _appDbContext.SaveChanges();
                return RedirectToAction("Detail",new { id = blogComment.BlogId });
            }

            return RedirectToAction("Detail", new { id = blogComment.BlogId , blogComment = blogComment });
        }
        //[HttpPost]
        //public IActionResult Reply(int? parentCommentid, int blogId, string email, string name, string text)
        //{

        //    if (_appDbContext.BlogComments.Find(parentCommentid) != null)
        //    {
        //        BlogComment blogComment = new();
        //        blogComment.BlogId = blogId;
        //        blogComment.Name = name;
        //        blogComment.Text = text;
        //        blogComment.Email = email;
        //        blogComment.ParentCommentId = parentCommentid;
        //        blogComment.CreatedDate = DateTime.Now;
        //        _appDbContext.BlogComments.Add(blogComment);

        //        _appDbContext.SaveChanges();
        //        return View("Detail",new { id = blogId });
        //    }

        //    return Json(new { isCheck = false });
        //}

        public IActionResult Reply(VmBlog vmBlog)
        {

            if (_appDbContext.BlogComments.Find(vmBlog.BlogComment.ParentCommentId) != null)
            {

                vmBlog.BlogComment.CreatedDate = DateTime.Now;
                _appDbContext.BlogComments.Add(vmBlog.BlogComment);

                _appDbContext.SaveChanges();
                return RedirectToAction("Detail", new { id = vmBlog.BlogComment.BlogId });
            }

            return RedirectToAction("Detail", new { id = vmBlog.BlogComment.BlogId });
        }

    }
}
