using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class SocialMedia
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30),Required]
        public string Name { get; set; }
        [MaxLength(50),Required]
        public string Icon { get; set; }
       
        public List<CastToSocial> CastToSocials { get; set; }
    }
}
