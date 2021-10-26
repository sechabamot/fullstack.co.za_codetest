using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoMute.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(string email)
        {
            UserName = email;
            Email = email;
        }

        public ApplicationUser(RegisterUserRequest request)
        {
            UserName = request.Email;
            Name = request.Name;
            Surname = request.Surname;
            Email = request.Email;
            PhoneNumber = request.Phone;
        }

        public string Name { get; set; }

        public string Surname { get; set; }

    }
}
