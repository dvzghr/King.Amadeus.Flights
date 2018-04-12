using Newtonsoft.Json;

namespace King.Amadeus.Flights.Api.Models.Amadeus.Flight
{
    public class Restrictions
    {
        [JsonProperty("refundable")]
        public bool Refundable { get; set; }

        [JsonProperty("change_penalties")]
        public bool ChangePenalties { get; set; }
    }
}