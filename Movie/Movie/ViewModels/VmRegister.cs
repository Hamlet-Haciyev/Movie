using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.ViewModels
{
    public class VmRegister
    {
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //public bool isUser = true;
    }
}
