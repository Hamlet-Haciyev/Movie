using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200),Required]
        public string Name { get; set; }
        public List<BlogToTag> BlogToTags { get; set; }

    }
}
