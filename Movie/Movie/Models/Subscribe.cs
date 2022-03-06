using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class Subscribe
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50),Required(ErrorMessage ="Please enter email address")]
        public string Mail { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
