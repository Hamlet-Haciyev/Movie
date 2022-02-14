using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30),Required(ErrorMessage ="Please enter genre name")]
        public string Name { get; set; }
        public List<MovieToGenre> MovieToGenres { get; set; }
    }
}
