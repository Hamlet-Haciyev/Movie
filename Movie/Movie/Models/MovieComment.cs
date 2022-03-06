using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class MovieComment
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30),Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; }
        [MaxLength(50),Required(ErrorMessage = "Enter your email")]
        public string Email { get; set; }
        [MaxLength(2000),Required(ErrorMessage = "Enter your message")]
        public string Text { get; set; }
        [Required]
        public byte Rating { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movies Movie { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
