using Newtonsoft.Json;
using System;

namespace King.Amadeus.Flights.Api.Models.Amadeus.Flight
{
    public class FlightInfo
    {
        [JsonProperty("departs_at")]
        public DateTime DepartsAt { get; set; }

        [JsonProperty("arrives_at")]
        public DateTime ArrivesAt { get; set; }

        [JsonProperty("origin")]
        public City Origin { get; set; }

        [JsonProperty("destination")]
        public City Destination { get; set; }

        [JsonProperty("marketing_airline")]
        public string MarketingAirline { get; set; }

        [JsonProperty("operating_airline")]
        public string OperatingAirline { get; set; }

        [JsonProperty("flight_number")]
        public string FlightNumber { get; set; }

        [JsonProperty("aircraft")]
        public string Aircraft { get; set; }

        [JsonProperty("booking_info")]
        public BookingInfo BookingInfo { get; set; }        
    }
}