using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class BlogComment
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30),Required]
        public string Name { get; set; }
        [MaxLength(50),Required]
        public string Email { get; set; }
        [MaxLength(2000),Required]
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("Blog")]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        [ForeignKey("ParentComment")]
        public int? ParentCommentId { get; set; }
        public BlogComment ParentComment { get; set; }
    }
}
