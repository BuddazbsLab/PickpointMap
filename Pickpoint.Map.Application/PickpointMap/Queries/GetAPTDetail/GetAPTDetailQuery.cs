using MediatR;
using PickpointMap_Backend.Queries.GetAPTDetail;

namespace Pickpoint.Map.Application.PickpointMap.Queries.GetAPTDetail
{
    public class GetAPTDetailQuery : IRequest<APTDetailVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
