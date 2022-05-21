using AutoMapper;
using PickpointMap_Backend;
using PickpointMap_Backend.Mappings;

namespace Pickpoint.Map.Application.PickpointMap.Queries.GetAPTList
{
    public class APTLookupDto : IMapWith<PickpointMapAll>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<PickpointMapAll, APTLookupDto>()
                .ForMember(APTDto => APTDto.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(APTDto => APTDto.Title,
                    opt => opt.MapFrom(pickpointMap => pickpointMap.Title));
        }

    }
}