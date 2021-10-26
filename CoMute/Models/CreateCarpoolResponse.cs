using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoMute.Models
{
    public class CreateCarpoolResponse
    {
        public CreateCarpoolResponse(bool result, string message, Carpool carpool)
        {
            IsSuccess = result;
            Message = message;
            Carpool = carpool;
        }

        [JsonProperty("isSuccess")]
        [Required]
        public bool IsSuccess { get; set; }

        [JsonProperty("message")]
        [Required]
        public string Message { get; set; }

        [JsonProperty("carpool")]
        [Required]
        public Carpool Carpool { get; set; }

    }
}
