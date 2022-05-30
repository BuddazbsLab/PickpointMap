using MediatR;


namespace Pickpoint.Map.Application.PickpointMap.Commands.CreateAPT
{
    public class CreateAPTCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string NumberPoint { get; set; }
        public string Details { get; set; }
    }
}
