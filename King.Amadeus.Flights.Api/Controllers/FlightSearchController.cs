using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using King.Amadeus.Flights.Api.Helpers;
using King.Amadeus.Flights.Api.Models.Dto;
using King.Amadeus.Flights.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace King.Amadeus.Flights.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class FlightSearchController : ControllerBase
    {
        private readonly IFlightSearchService service;

        public FlightSearchController(IFlightSearchService service)
        {
            this.service = service;
        }

        [HttpGet]
        [ResponseCache(Duration = 600, VaryByQueryKeys = new[] { "*" })]
        public async Task<List<SearchResultDto>> Get([FromQuery] FlightSearchDto flightSearch)
        {
            var serviceResult = await service.GetFlights(flightSearch);
            var result = serviceResult.ExportToSearchResultDtos();

            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}