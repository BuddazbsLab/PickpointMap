using AutoMapper;
using Pickpoint.Map.Application.PickpointMap.Commands.CreateAPT;
using PickpointMap_Backend.Mappings;

namespace PickpointMap_Backend.PickPointMap.WebApi.Model
{
    public class CreatePickpointMapAPT : IMapWith<CreateAPTCommand>
    {
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePickpointMapAPT, CreateAPTCommand>()
                .ForMember(noteCommand => noteCommand.Title, opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.Details, opt => opt.MapFrom(noteDto => noteDto.Details));
        }
    }
}
