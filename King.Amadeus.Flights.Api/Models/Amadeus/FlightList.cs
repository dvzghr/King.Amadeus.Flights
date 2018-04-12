using Newtonsoft.Json;
using King.Amadeus.Flights.Api.Models.Amadeus.Flight;
using System.Collections.Generic;

namespace King.Amadeus.Flights.Api.Models
{
    public class FlightList
    {
        [JsonProperty("flights")]
        public IEnumerable<FlightInfo> Flights { get; set; }
    }
}