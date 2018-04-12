using System.Collections.Generic;
using King.Amadeus.Flights.Api.Models.Amadeus.Flight;
using Newtonsoft.Json;

namespace King.Amadeus.Flights.Api.Models.Amadeus
{
    public class Result
    {
        [JsonProperty("itineraries")]
        public IEnumerable<Itinerary> Itineraries { get; set; }

        [JsonProperty("fare")]
        public Fare Fare { get; set; }
    }
}