using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoMute.Models
{
    public class CarpoolPassangers
    {
        public CarpoolPassangers()
        {

        }

        public CarpoolPassangers(string userName)
        {
            UserName = userName;
        }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("dateJoined")]
        public DateTime DateJoined { get; set; }

    }
}
