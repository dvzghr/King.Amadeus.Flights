using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using King.Amadeus.Flights.Api.Models.Amadeus;
using King.Amadeus.Flights.Api.Models.Dto;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace King.Amadeus.Flights.Api.Services
{
    public interface IFlightSearchService
    {
        Task<FlightSearch> GetFlights(FlightSearchDto flightSearch);
    }

    public class AmadeusFlightSearchService : IFlightSearchService
    {
        public async Task<FlightSearch> GetFlights(FlightSearchDto flightSearch)
        {
            var url = "v1.2/flights/low-fare-search";
            var parameters = new[]
                             {
                                 new Parameter
                                 {
                                     Name = "apikey",
                                     Type = ParameterType.QueryString,
                                     Value = Environment.GetEnvironmentVariable("apikey")},
                                 new Parameter
                                 {
                                     Name = "origin",
                                     Type = ParameterType.QueryString,
                                     Value = flightSearch.Origin
                                 },
                                 new Parameter
                                 {
                                     Name = "destination",
                                     Type = ParameterType.QueryString,
                                     Value = flightSearch.Destination
                                 },
                                 new Parameter
                                 {
                                     Name = "departure_date",
                                     Type = ParameterType.QueryString,
                                     Value = flightSearch.DepartureDate.ToString("yyyy-MM-dd")
                                 },
                                 new Parameter
                                 {
                                     Name = "return_date",
                                     Type = ParameterType.QueryString,
                                     Value = flightSearch.ReturnDate.ToString("yyyy-MM-dd")
                                 },
                                 new Parameter
                                 {
                                     Name = "adults",
                                     Type = ParameterType.QueryString,
                                     Value = flightSearch.NumberOfPassengers
                                 },
                                 new Parameter
                                 {
                                     Name = "currency",
                                     Type = ParameterType.QueryString,
                                     Value = flightSearch.Currency
                                 }
                             };

            return await GetApiResponseAsync<FlightSearch>(url, parameters);
        }

        private async Task<T> GetApiResponseAsync<T>(string url, IEnumerable<Parameter> parameters = null)
        {
            var request = new RestRequest(url, Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (parameters != null)
                request.Parameters.AddRange(parameters);

            var client = new RestClient("https://api.sandbox.amadeus.com/");
            var result = await client.ExecuteGetTaskAsync<T>(request);
            return result.Data;
        }
    }
}