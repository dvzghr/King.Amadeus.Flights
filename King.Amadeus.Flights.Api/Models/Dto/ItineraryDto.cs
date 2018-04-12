using System.Collections.Generic;
using System.Linq;

namespace King.Amadeus.Flights.Api.Models.Dto
{
    public class ItineraryDto
    {
        public IEnumerable<FlightDto> OutboundFlights { get; set; }

        public IEnumerable<FlightDto> InboundFlights { get; set; }

        public static explicit operator ItineraryDto(Itinerary itinerary) =>
            new ItineraryDto
            {
                InboundFlights = itinerary.Inbound.Flights.Select(flight => (FlightDto) flight),
                OutboundFlights = itinerary.Outbound.Flights.Select(flight => (FlightDto) flight)
            };
    }
}