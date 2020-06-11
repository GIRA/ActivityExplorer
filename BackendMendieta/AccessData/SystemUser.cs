using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Login.Data
{
    public partial class SystemUser : IdentityUser<string>
    {

        public SystemUser()
        {

        }

        public SystemUser(string id, string name, string lastName, string city, string dni, string email, string phone, string institution, string image, string password)
        {
            this.Id = id;
            this.FirstName = name;
            this.LastName = lastName;
            this.UserName = name + lastName;
            this.City = city;
            this.Dni = dni;
            this.Email = email;
            this.PhoneNumber = phone;
            this.Institution = institution;
            this.ImageFileName = image;

            PasswordHasher<SystemUser> passwordHasher = new PasswordHasher<SystemUser>();
            this.PasswordHash = passwordHasher.HashPassword(this, password);
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Dni { get; set; }

        public string Institution { get; set; }

        public string ImageFileName { get; set; }
        
    }
}
