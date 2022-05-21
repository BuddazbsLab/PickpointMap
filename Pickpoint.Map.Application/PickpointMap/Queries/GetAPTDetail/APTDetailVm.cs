using AutoMapper;
using PickpointMap_Backend.Mappings;

namespace PickpointMap_Backend.Queries.GetAPTDetail
{
    public class APTDetailVm : IMapWith<PickpointMapAll>
    {


        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PickpointMapAll, APTDetailVm>()
                .ForMember(noteVm => noteVm.Id, opt => opt.MapFrom(note => note.Id))
                .ForMember(noteVm => noteVm.Title, opt => opt.MapFrom(note => note.Title))
                .ForMember(noteVm => noteVm.Details, opt => opt.MapFrom(note => note.Details))
                .ForMember(noteVm => noteVm.CreationDate, opt => opt.MapFrom(note => note.CreationDate))
                .ForMember(noteVm => noteVm.EditDate, opt => opt.MapFrom(note => note.EditDate));
        }
    }
}
