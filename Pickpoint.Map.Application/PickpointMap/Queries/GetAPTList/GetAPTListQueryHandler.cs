using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickpointMap_Backend.Interface;

namespace Pickpoint.Map.Application.PickpointMap.Queries.GetAPTList
{
    public class GetAPTListQueryHandler : IRequestHandler<GetAPTListQuery, APTListVm>
    {
        private readonly IPickpointMapDbContext _dbContext;
        private readonly IMapper _mapper;


        public GetAPTListQueryHandler(IPickpointMapDbContext dbContext,
           IMapper mapper) =>
           (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<APTListVm> Handle(GetAPTListQuery request,
            CancellationToken cancellationToken)
        {
            var pickpointQuery = await _dbContext.PickpointMaps
                .Where(note => note.UserId == request.UserId)
                .ProjectTo<APTLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new APTListVm { Point = pickpointQuery };


        }
    }
}
