using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoMute.Models
{
    public class JoinOrLeaveCarpoolResponse
    {
        public JoinOrLeaveCarpoolResponse()
        {

        }

        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("carpool")]
        public Carpool Carpool { get; set; }
    }
}
