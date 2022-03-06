using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30),Required]
        public string Name { get; set; }
        [MaxLength(50), Required]
        public string Email { get; set; }
        [MaxLength(30), Required]
        public string Phone { get; set; }
        [MaxLength(50), Required]
        public string Subject { get; set; }
        [MaxLength(2000), Required]
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
