using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace King.Amadeus.Flights.Api.Models.Amadeus
{
    public class FlightSearch
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("results")]
        public IEnumerable<Result> Results { get; set; }
    }
}

