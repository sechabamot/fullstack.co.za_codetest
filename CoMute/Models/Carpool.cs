using CoMuse.Models;
using CoMute.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoMute.Models
{
    public class Carpool
    {
        public Carpool()
        {

        }
        public Carpool(CreateCarpoolRequest request)
        {
            Owner = request.Owner;
            OriginAddress = request.OriginAddress;
            DestinationAddress = request.DestinationAddress;
            Notes = request.Notes;
            NoSeatsAvailable = request.NoSeatsAvailable;
            DaysAvailable = request.DaysAvailable;
            ArrivalTime = request.ArrivalTime;
            DepartureTime = request.DepartureTime;
            DateCreated = DateTime.UtcNow;
            Passangers = new List<CarpoolPassangers>();
        }

        [JsonProperty("id")]
        public string Id { get; set; }

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

        public string Passangers_Serialized { get; set; }

        [JsonProperty("passangers")]
        [Required]
        [NotMapped]
        public List<CarpoolPassangers> Passangers 
        {
            get => JsonConvert.DeserializeObject<List<CarpoolPassangers>>(Passangers_Serialized ?? "") ?? new List<CarpoolPassangers>(); 
            set => Passangers_Serialized = JsonConvert.SerializeObject(value) ?? ""; 
        }


        [JsonProperty("noSeatsAvailable")]
        [Required]
        public int NoSeatsAvailable { get; set; }

        private string DaysAvailable_Serialised { get; set; }

        [JsonProperty("dayAvailable")]
        [Required]
        [NotMapped]
        public List<Day> DaysAvailable 
        {
            get => JsonConvert.DeserializeObject<List<Day>>(DaysAvailable_Serialised ?? "");
            set => DaysAvailable_Serialised = JsonConvert.SerializeObject(value) ?? "";
        }

        [JsonProperty("dateCreated")]
        [Required]
        public DateTime DateCreated { get; set; }

        [JsonProperty("arrivalTime")]
        [Required]
        public TimeSpan ArrivalTime { get; set; }

        [JsonProperty("departureTime")]
        [Required]
        public TimeSpan DepartureTime { get; set; }
    }
}
