using Newtonsoft.Json;

namespace King.Amadeus.Flights.Api.Models.Amadeus.Flight
{
    public class Fare
    {
        [JsonProperty("total_price")]
        public decimal TotalPrice { get; set; }

        [JsonProperty("price_per_adult")]
        public PricePerAdult PricePerAdult { get; set; }

        [JsonProperty("restrictions")]
        public Restrictions Restrictions { get; set; }
    }
}