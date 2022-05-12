using Microsoft.AspNetCore.Mvc;

namespace PickpointMap_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapApi : ControllerBase
    {
        private static readonly int[] CountPoint = new[]
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };

        private readonly ILogger<MapApi> _logger;

        public MapApi(ILogger<MapApi> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Map>>> GetItems()
        {
            Random rng = new();
            return Enumerable.Range(1, 1).Select(index => new Map
            {
                Date = DateTime.Now.AddDays(index),
                CountPoint =  CountPoint[rng.Next(0, 9)]
            })
            .ToArray();
        }
    }
}