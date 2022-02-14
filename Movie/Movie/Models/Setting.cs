using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Logo { get; set; }
        [NotMapped]
        public IFormFile LogoFile { get; set; }
        [MaxLength(500),Required(ErrorMessage = "Please leave this field empty")]
        public string Address { get; set; }
        [MaxLength(50),Required(ErrorMessage = "Please leave this field empty")]
        public string Email { get; set; }
        [MaxLength(30), Required(ErrorMessage = "Please leave this field empty")]
        public string Phone { get; set; }
        [Column(TypeName ="ntext"),Required]
        public string About { get; set; }
        [NotMapped]
        public string base64 { get; set; }
    }
}
