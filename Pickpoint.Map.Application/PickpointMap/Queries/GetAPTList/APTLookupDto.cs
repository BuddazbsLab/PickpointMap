using AutoMapper;
using PickpointMap_Backend;
using PickpointMap_Backend.Mappings;

namespace Pickpoint.Map.Application.PickpointMap.Queries.GetAPTList
{
    public class APTLookupDto : IMapWith<PickpointMapAll>
    {
        public Guid Id { get; set; }
        public string NumberPoint { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<PickpointMapAll, APTLookupDto>()
                .ForMember(APTDto => APTDto.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(APTDto => APTDto.NumberPoint,
                    opt => opt.MapFrom(pickpointMap => pickpointMap.NumberPoint));
        }

    }
}