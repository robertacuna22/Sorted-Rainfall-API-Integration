using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sorted.Business.IContract;
using Sorted.Rainfall;


namespace Sorted.API.Controllers
{
    [ApiController]
    public class RainFallController : ControllerBase
    {
        private readonly ISortedReadingStationService _service;

        public RainFallController(ISortedReadingStationService service)
        {
            _service = service;
        }

        [HttpGet("/rainfall/id/{stationId}/readings")]

        public async Task<IActionResult> GetStationReading(string stationId, int count = 10)
        {
            var results = await _service.GetStationReading(stationId, count);

            if (!results.Any())
            {
                return NotFound();
            }

            return Ok(results);
        }

    }
}
