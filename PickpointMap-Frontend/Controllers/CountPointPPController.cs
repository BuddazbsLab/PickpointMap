using Microsoft.AspNetCore.Mvc;

namespace PickpointMap_Frontend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountPointPPController : ControllerBase
    {
        private static readonly int[] Summaries = new[]
        {
        1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18
        };

        private readonly ILogger<CountPointPPController> _logger;

        public CountPointPPController(ILogger<CountPointPPController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<PickpointPoint> GetPoint()
        {
            return Enumerable.Range(1, 5).Select(index => new PickpointPoint
            {
                Date = DateTime.Now.AddDays(index),
                Point = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}