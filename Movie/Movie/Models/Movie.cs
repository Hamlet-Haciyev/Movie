using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Title { get; set; }
        [Column(TypeName ="ntext")]
        public string Description { get; set; }
        [MaxLength(20)]
        public string RunTime { get; set; }
        [MaxLength(150)]
        public string Tagline { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [MaxLength(250)]
        public string Trailer { get; set; }
        [NotMapped]
        public IFormFile TrailerFile { get; set; }
        [MaxLength(250)]
        public string Video { get; set; }
        [NotMapped]
        public IFormFile VideoFile { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<MovieToGenre> MovieToGenres { get; set; }
        public List<MovieToWriter> MovieToWriters { get; set; }
        public List<MovieToDirector> MovieToDirectors { get; set; }
        public List<MovieToCast> MovieToCasts { get; set; }
        public List<MovieComment> MovieComments { get; set; }
        [NotMapped]
        public string ImageBase64 { get; set; }
        [NotMapped]
        public string VideoBase64 { get; set; }
        [NotMapped]
        public string TrailerBase64 { get; set; }
        [NotMapped]
        public List<int> WriterIds { get; set; }
        [NotMapped]
        public List<int> GenresIds { get; set; }
        [NotMapped]
        public List<int> CastIds { get; set; }
        [NotMapped]
        public int DirectorId { get; set; }
    }
}
