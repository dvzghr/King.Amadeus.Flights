using Newtonsoft.Json;

namespace King.Amadeus.Flights.Api.Models.Amadeus.Flight
{
    public class BookingInfo
    {
        [JsonProperty("travel_class")]
        public string TravelClass { get; set; }

        [JsonProperty("booking_code")]
        public string BookingCode { get; set; }

        [JsonProperty("seats_remaining")]
        public long SeatsRemaining { get; set; }
    }
}