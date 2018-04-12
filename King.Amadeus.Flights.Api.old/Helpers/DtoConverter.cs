using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using King.Amadeus.Flights.Api.Models.Amadeus;
using King.Amadeus.Flights.Api.Models.Dto;

namespace King.Amadeus.Flights.Api.Helpers
{
    public static class DtoConverter
    {
        public static List<SearchResultDto> ExportToSearchResultDtos(this FlightSearch flightSearch)
        {
            var results = flightSearch.Results.Select(result => new SearchResultDto
                                                                {
                                                                    Itineraries = result.Itineraries.Select(itinerary => (ItineraryDto) itinerary),
                                                                    TotalPrice = result.Fare.TotalPrice
                                                                });
            return results.ToList();
        }
    }
}