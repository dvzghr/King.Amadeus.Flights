using System;
using System.Net;

namespace King.Amadeus.Flights.Api.Models.Amadeus
{
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message) { }

        public HttpStatusCode StatusCode { get; set; }
    }
}