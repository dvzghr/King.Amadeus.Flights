using System.Threading.Tasks;
using King.Amadeus.Flights.Api.Models.Amadeus;
using King.Amadeus.Flights.Api.Models.Dto;

namespace King.Amadeus.Flights.Api.Services {
    public interface IFlightSearchService
    {
        Task<FlightSearch> GetFlights(FlightSearchDto flightSearch);
    }
}