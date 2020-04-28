using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Login.Data
{
    public partial class SystemUser
    {

        public SystemUser()
        {
            Login = new HashSet<Login>();
        }

        public SystemUser(int id, string name, string lastName, string city, string dni, string email, string phone, string institution, string image, string password)
        {
            this.SystemUserId = id;
            this.SystemUserName = name;
            this.SystemUserLastName = lastName;
            this.SystemUserCity = city;
            this.SystemUserDni = dni;
            this.SystemUserEmail = email;
            this.SystemUserPhone = phone;
            this.SystemUserInstitution = institution;
            this.SystemUserImage = image;
            this.SystemUserPassword = password;
        }

        public int SystemUserId { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        [Display(Name = "Name")]
        public string SystemUserName { get; set; }
        [Required(ErrorMessage = "Mandatory")]
        [Display(Name = "Last Name")]
        public string SystemUserLastName { get; set; }
        [Required(ErrorMessage = "Mandatory")]
        [Display(Name = "City")]
        public string SystemUserCity { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        [Display(Name = "DNI")]
        public string SystemUserDni { get; set; }
        [Required(ErrorMessage = "Mandatory")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string SystemUserEmail { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string SystemUserPhone { get; set; }

        [Display(Name = "Institution")]
        public string SystemUserInstitution { get; set; }

        [Display(Name = "Image")]
        public string SystemUserImage { get; set; }

        [Required(ErrorMessage = "Mandatory")]
        [Display(Name = "Last Name")]
        [DataType(DataType.Password)]
        public string SystemUserPassword { get; set; }

        public virtual ICollection<Login> Login { get; set; }
    }
}
