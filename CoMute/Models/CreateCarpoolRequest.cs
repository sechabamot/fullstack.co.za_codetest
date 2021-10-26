using CoMuse.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoMute.Models
{
    public class CreateCarpoolRequest
    {

        [JsonProperty("owner")]
        [Required]
        public string Owner { get; set; }

        [JsonProperty("originAddress")]
        [Required]
        public string OriginAddress { get; set; }

        [JsonProperty("destinationAdress")]
        [Required]
        public string DestinationAddress { get; set; }

        [JsonProperty("notes")]
        [Required]
        public string Notes { get; set; }

        [JsonProperty("noSeatsAvailable")]
        [Required]
        public int NoSeatsAvailable { get; set; }

        [JsonProperty("dayAvailable")]
        [Required]
        public List<Day> DaysAvailable { get; set; }

        [JsonProperty("arrivalTime")]
        [Required]
        public TimeSpan ArrivalTime { get; set; }

        [JsonProperty("departureTime")]
        [Required]
        public TimeSpan DepartureTime { get; set; }

    }
}
