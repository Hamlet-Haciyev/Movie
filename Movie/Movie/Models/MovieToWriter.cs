using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class MovieToWriter
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movies Movie { get; set; }
        [ForeignKey("Writer")]
        public int WriterId { get; set; }
        public Writer Writer { get; set; }
    }
}
