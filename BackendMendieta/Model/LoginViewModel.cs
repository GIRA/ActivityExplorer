using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Login.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Mandatory")]
        [Display(Name = "Email Adress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [JsonIgnore]
        public string Password { get; set; }
    }
}
