using Newtonsoft.Json;

namespace King.Amadeus.Flights.Api.Models.Amadeus.Flight
{
    public class PricePerAdult
    {
        [JsonProperty("total_fare")]
        public decimal TotalFare { get; set; }

        [JsonProperty("tax")]
        public decimal Tax { get; set; }
    }
}