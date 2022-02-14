using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30),Required]
        public string Name { get; set; }
        public List<Cast> Casts { get; set; }
    }
}
