using MediatR;
using PickpointMap_Backend.Interface;
using PickpointMap_Backend;

namespace Pickpoint.Map.Application.PickpointMap.Commands.CreateAPT
{
    public class CreateAPTCommandHandler : IRequestHandler<CreateAPTCommand, Guid>
    {
        private readonly IPickpointMapDbContext _dbContext;
        public CreateAPTCommandHandler(IPickpointMapDbContext dbContext) => _dbContext = dbContext;
        public async Task<Guid> Handle(CreateAPTCommand request, CancellationToken cancellationToken)
        {
            var note = new PickpointMapAll
            {
                UserId = request.UserId,
                NumberPoint = request.NumberPoint,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };


            await _dbContext.PickpointMaps.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}
