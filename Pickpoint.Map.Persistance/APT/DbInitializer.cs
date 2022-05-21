namespace PickpointMap_Backend.Persistence.APT
{
    public class DbInitializer
    {
        public static void Initialize(PickpointMapDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
