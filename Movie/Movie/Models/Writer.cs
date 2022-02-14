using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30),Required(ErrorMessage ="Please enter writer name")]
        public string Name { get; set; }
        public List<MovieToWriter> MovieToWriters { get; set; }

    }
}
