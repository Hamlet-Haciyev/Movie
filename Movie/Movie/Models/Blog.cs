using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200),Required]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [Column(TypeName ="ntext"),Required(ErrorMessage ="Please enter description")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<BlogComment> BlogComments { get; set; }
        public List<BlogToTag> BlogToTags { get; set; }
        [NotMapped]
        public string base64 { get; set; }
        [NotMapped]
        public List<int> TagId { get; set; }
    }
}
