using System.Collections.Generic;
using System.Linq;
using King.Amadeus.Flights.Api.Models.Amadeus;

namespace King.Amadeus.Flights.Api.Models.Dto
{
    public class ItineraryDto
    {
        public IEnumerable<FlightDto> OutboundFlights { get; set; }

        public IEnumerable<FlightDto> InboundFlights { get; set; }

        public int OutboundTransfers => OutboundFlights.Count() - 1;

        public int InboundTransfers => InboundFlights.Count() - 1;

        public static explicit operator ItineraryDto(Itinerary itinerary) =>
            new ItineraryDto
            {
                InboundFlights = itinerary.Inbound.Flights.Select(flight => (FlightDto) flight),
                OutboundFlights = itinerary.Outbound.Flights.Select(flight => (FlightDto) flight)
            };
    }
}