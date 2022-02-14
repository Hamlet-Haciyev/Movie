using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class CastToSocial
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("SocialMedia")]
        public int SocialMediaId { get; set; }
        public SocialMedia SocialMedia { get; set; }

        [ForeignKey("Cast")]
        public int CastId { get; set; }
        public Cast Cast { get; set; }
        [MaxLength(250), Required]
        public string Link { get; set; }
    }
}
