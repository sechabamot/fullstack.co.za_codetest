using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoMute.Models
{
    public class RegisterUserRequest
    {
        [JsonProperty("name")]
        [Required]
        public string Name { get; set; }

        [JsonProperty("surname")]
        [Required]
        public string Surname { get; set; }

        [JsonProperty("email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [JsonProperty("phone")]
        [Phone]
        public string Phone { get; set; }

        [JsonProperty("password")]
        [Required]
        public string Password { get; set; }

    }
}
