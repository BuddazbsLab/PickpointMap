using MediatR;
using Microsoft.EntityFrameworkCore;
using PickpointMap_Backend.Exceptions;
using PickpointMap_Backend.Interface;


namespace Pickpoint.Map.Application.PickpointMap.Commands.UpdateAPT
{
    public class UpdateAPTCommandHandler : IRequestHandler<UpdateAPTCommand>
    {
        private readonly IPickpointMapDbContext _dbContext;

        public UpdateAPTCommandHandler(IPickpointMapDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateAPTCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.PickpointMaps.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(PickpointMap), request.Id);
            }

            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
