using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class Banner
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50),Required]
        public string Title { get; set; }
        [MaxLength(250),Required]
        public string SubtTitle { get; set; }
        [MaxLength(50), Required]
        public string Page { get; set; }
    }
}
