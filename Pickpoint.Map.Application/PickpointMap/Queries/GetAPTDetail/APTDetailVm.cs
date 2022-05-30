using AutoMapper;
using PickpointMap_Backend.Mappings;

namespace PickpointMap_Backend.Queries.GetAPTDetail
{
    public class APTDetailVm : IMapWith<PickpointMapAll>
    {


        public Guid Id { get; set; }
        public string NumberPoint { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PickpointMapAll, APTDetailVm>()
                .ForMember(noteVm => noteVm.Id, opt => opt.MapFrom(note => note.Id))
                .ForMember(noteVm => noteVm.NumberPoint, opt => opt.MapFrom(note => note.NumberPoint))
                .ForMember(noteVm => noteVm.Details, opt => opt.MapFrom(note => note.Details))
                .ForMember(noteVm => noteVm.CreationDate, opt => opt.MapFrom(note => note.CreationDate))
                .ForMember(noteVm => noteVm.EditDate, opt => opt.MapFrom(note => note.EditDate));
        }
    }
}
