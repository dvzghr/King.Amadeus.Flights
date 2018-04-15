using King.Amadeus.Flights.Api.Models.Amadeus;
using Newtonsoft.Json;

namespace King.Amadeus.Flights.Api.Models
{
    public class Itinerary
    {
        [JsonProperty("outbound")]
        public FlightList Outbound { get; set; }

        [JsonProperty("inbound")]
        public FlightList Inbound { get; set; }
    }
}