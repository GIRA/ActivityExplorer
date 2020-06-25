using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Login.Models
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {

        }
        public RegisterViewModel(string id, string name, string lastName, string city, string dni, string email, string phone, string institution, string image, string password)
        {
            this.Id = id;
            this.FirstName = name;
            this.LastName = lastName;
            this.City = city;
            this.Dni = dni;
            this.Email = email;
            this.PhoneNumber = phone;
            this.Institution = institution;
            this.ImageFileName = image;
        }

        public string Id { get; set; }
        [Required(ErrorMessage = "Mandatory")]
        [Display(Name = "Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        [Display(Name = "DNI")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        [Display(Name = "Email Adress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Institution")]
        public string Institution { get; set; }

        [Display(Name = "Image")]
        public string ImageFileName { get; set; }
        
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [JsonIgnore]
        public string Password { get; set; }
    }
}
