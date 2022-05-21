using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PickpointMap_Backend.Persistence.APT.EntityTypeConfigurations
{
    public class PickpointMapConfiguation : IEntityTypeConfiguration<PickpointMapAll>
    {
        public void Configure(EntityTypeBuilder<PickpointMapAll> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id);
            builder.Property(note => note.CountPoint).HasMaxLength(250);
        }
    }
}
