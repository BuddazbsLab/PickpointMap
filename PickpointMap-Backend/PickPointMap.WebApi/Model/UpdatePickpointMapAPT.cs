using AutoMapper;
using PickpointMap_Backend.Mappings;
using Pickpoint.Map.Application.PickpointMap.Commands.UpdateAPT;

namespace PickpointMap_Backend.PickPointMap.WebApi.Model
{
    public class UpdatePickpointMapAPT : IMapWith<UpdateAPTCommand>
    {
        public Guid Id { get; set; }
        public string NumberPoint { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePickpointMapAPT, UpdateAPTCommand>()
                .ForMember(noteCommand => noteCommand.Id, opt => opt.MapFrom(noteDto => noteDto.Id))
                .ForMember(noteCommand => noteCommand.NumberPoint, opt => opt.MapFrom(noteDto => noteDto.NumberPoint))
                .ForMember(noteCommand => noteCommand.Details, opt => opt.MapFrom(noteDto => noteDto.Details));
        }

    }
}
