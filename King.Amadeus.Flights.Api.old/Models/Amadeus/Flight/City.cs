using Newtonsoft.Json;

namespace King.Amadeus.Flights.Api.Models.Amadeus.Flight
{
    public class City
    {
        [JsonProperty("airport")]
        public string Airport { get; set; }

        [JsonProperty("terminal")]
        public string Terminal { get; set; }
    }
}