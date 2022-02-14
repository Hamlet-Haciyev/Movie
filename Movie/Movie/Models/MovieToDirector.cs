using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class MovieToDirector
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movies Movie { get; set; }
        [ForeignKey("Director")]
        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}
