using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class MovieToCast
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movies Movie { get; set; }
        [ForeignKey("Cast")]
        public int CastId { get; set; }
        public Cast Cast { get; set; }
    }
}
