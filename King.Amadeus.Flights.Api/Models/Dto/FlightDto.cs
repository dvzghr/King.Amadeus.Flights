using System;
using King.Amadeus.Flights.Api.Models.Amadeus.Flight;

namespace King.Amadeus.Flights.Api.Models.Dto
{
    public class FlightDto
    {
        public DateTime DepartureDate { get; set; }

        public DateTime ArrivalDate { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public static explicit operator FlightDto(FlightInfo flightInfo) =>
            new FlightDto
            {
                Origin = flightInfo.Origin.Airport,
                Destination = flightInfo.Destination.Airport,
                ArrivalDate = flightInfo.ArrivesAt,
                DepartureDate = flightInfo.DepartsAt
            };
    }
}