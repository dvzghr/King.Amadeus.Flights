using System;
using System.Net;
using System.Threading.Tasks;
using King.Amadeus.Flights.Api.Helpers;
using King.Amadeus.Flights.Api.Models.Amadeus;
using King.Amadeus.Flights.Api.Models.Dto;
using King.Amadeus.Flights.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace King.Amadeus.Flights.Api.Controllers
{
    /// <summary>
    /// King hiring test: Amadeus Flight Search api
    /// Date: 16.4.2018.
    /// Author: Dražen Vuković
    /// Email: ths_hr@hotmail.com
    /// </summary>
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
        public async Task<IActionResult> Get([FromQuery] FlightSearchDto flightSearch)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                                  {
                                      message = "Invalid or missing input parameters."
                                  });

            FlightSearch serviceResult;

            try
            {
                serviceResult = await service.GetFlights(flightSearch);
            }
            catch (ApiException ex)
            {
                return StatusCode((int) ex.StatusCode,
                                  new
                                  {
                                      message = ex.Message
                                  });
            }
            catch (Exception ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError,
                                  new
                                  {
                                      message = ex.Message
                                  });
            }

            var result = serviceResult.ExportToSearchResultDtos();

            return Ok(result);
        }
    }
}