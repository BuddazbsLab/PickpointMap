using AutoMapper;

namespace PickpointMap_Backend.Mappings
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());

    }
}
