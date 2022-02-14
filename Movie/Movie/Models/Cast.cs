
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class Cast
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50),Required]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [MaxLength(250),Required]
        public string BirthPlace { get; set; }
        [Column(TypeName ="ntext"),Required(ErrorMessage ="Please enter cast about information")]
        public string About { get; set; }
        [ForeignKey("Gender")]
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public List<CastToSocial> CastToSocials { get; set; }
        public List<MovieToCast> MovieToCasts { get; set; }
        [NotMapped]
        public List<int> SocialMediaIds { get; set; }
        [NotMapped]
        public string base64 { get; set; }

    }
}
