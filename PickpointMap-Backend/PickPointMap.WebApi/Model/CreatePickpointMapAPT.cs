using AutoMapper;
using Pickpoint.Map.Application.PickpointMap.Commands.CreateAPT;
using PickpointMap_Backend.Mappings;

namespace PickpointMap_Backend.PickPointMap.WebApi.Model
{
    public class CreatePickpointMapAPT : IMapWith<CreateAPTCommand>
    {
        public string NumberPoint { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePickpointMapAPT, CreateAPTCommand>()
                .ForMember(noteCommand => noteCommand.NumberPoint, opt => opt.MapFrom(noteDto => noteDto.NumberPoint))
                .ForMember(noteCommand => noteCommand.Details, opt => opt.MapFrom(noteDto => noteDto.Details));
        }
    }
}
