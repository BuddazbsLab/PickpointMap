using Microsoft.EntityFrameworkCore;
using PickpointMap_Backend.Persistence.APT.EntityTypeConfigurations;

namespace PickpointMap_Backend.Persistence.APT
{
    public class PickpointMapDbContext : DbContext
    {
        public DbSet<PickpointMapDbContext> PickpointMaps { get; set; }

        public PickpointMapDbContext(DbContextOptions<PickpointMapDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PickpointMapConfiguation());
            base.OnModelCreating(builder);
        }
    }
}
