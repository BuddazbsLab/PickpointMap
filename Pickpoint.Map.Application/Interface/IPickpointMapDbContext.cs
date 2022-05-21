using Microsoft.EntityFrameworkCore;


namespace PickpointMap_Backend.Interface
{
    public interface IPickpointMapDbContext
    {
        DbSet<PickpointMapAll> PickpointMaps { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
