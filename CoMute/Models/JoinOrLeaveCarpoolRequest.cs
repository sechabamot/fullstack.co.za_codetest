using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoMute.Models
{
    public class JoinOrLeaveCarpoolRequest
    {
        [JsonProperty("carpoolId")]
        [Required]
        public string CarpoolId { get; set; }

        [JsonProperty("passangerUserName")]
        [Required]
        public string PassangerUserName { get; set; }
    }
}
