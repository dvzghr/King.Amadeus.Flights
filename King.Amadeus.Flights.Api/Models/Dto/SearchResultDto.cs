using System.Collections.Generic;

namespace King.Amadeus.Flights.Api.Models.Dto {
    public class SearchResultDto
    {
        public IEnumerable<ItineraryDto> Itineraries { get; set; }

        public decimal TotalPrice { get; set; }
    }
}