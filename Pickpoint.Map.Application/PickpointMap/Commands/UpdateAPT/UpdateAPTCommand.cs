using MediatR;


namespace Pickpoint.Map.Application.PickpointMap.Commands.UpdateAPT
{
    public class UpdateAPTCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string NumberPoint { get; set; }
        public string Details { get; set; }
    }
}
