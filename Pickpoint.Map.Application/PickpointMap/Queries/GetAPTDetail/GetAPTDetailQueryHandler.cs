using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickpointMap_Backend;
using PickpointMap_Backend.Exceptions;
using PickpointMap_Backend.Interface;
using PickpointMap_Backend.Queries.GetAPTDetail;

namespace Pickpoint.Map.Application.PickpointMap.Queries.GetAPTDetail
{
    public class GetAPTDetailQueryHandler : IRequestHandler<GetAPTDetailQuery, APTDetailVm>
    {
        private readonly IPickpointMapDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAPTDetailQueryHandler(IPickpointMapDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);


        public async Task<APTDetailVm> Handle(GetAPTDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.PickpointMaps.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(PickpointMapAll), request.Id);
            }

            return _mapper.Map<APTDetailVm>(entity);
        }
    }
}
