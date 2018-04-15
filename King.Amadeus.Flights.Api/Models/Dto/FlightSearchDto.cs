using System;
using System.ComponentModel.DataAnnotations;

namespace King.Amadeus.Flights.Api.Models.Dto
{
    public class FlightSearchDto
    {
        [Required]
        public string Origin { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        [Required]
        public int NumberOfPassengers { get; set; }
        [Required]
        public string Currency { get; set; }
    }
}