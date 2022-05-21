using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PickpointMap_Backend.Queries.GetAPTDetail;

namespace PickpointMap_Backend.PickPointMap.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapApi : BaseController
    {
        private readonly IMapper _mapper;
        public MapApi(IMapper mapper) => _mapper = mapper;


        private static readonly int[] CountPoint = new[]
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };



        [HttpGet]
        public async Task<ActionResult<IEnumerable<APTDetailVm>>> GetItems()
        {
            Random rng = new();
            return Enumerable.Range(1, 1).Select(index => new APTDetailVm
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Details = "APT 0001-001",
                Title = "APT 0001-001",
                EditDate = DateTime.Now,

            })
            .ToArray();
        }
    }
}