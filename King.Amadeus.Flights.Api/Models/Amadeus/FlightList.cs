using System.Collections.Generic;
using King.Amadeus.Flights.Api.Models.Amadeus.Flight;
using Newtonsoft.Json;

namespace King.Amadeus.Flights.Api.Models.Amadeus
{
    public class FlightList
    {
        [JsonProperty("flights")]
        public IEnumerable<FlightInfo> Flights { get; set; }
    }
}