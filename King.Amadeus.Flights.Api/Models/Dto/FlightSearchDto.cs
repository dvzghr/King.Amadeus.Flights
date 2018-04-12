using System;

namespace King.Amadeus.Flights.Api.Models.Dto
{
    public class FlightSearchDto
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int NumberOfPassengers { get; set; }

        public string Currency { get; set; }
    }
}