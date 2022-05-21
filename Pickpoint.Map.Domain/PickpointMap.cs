namespace PickpointMap_Backend
{
    public class PickpointMapAll
    {
        public DateTime Date { get; init; }
        public Guid Id { get; set; }
        public int CountPoint { get; init; }
        public Guid UserId { get; set; }
        public string Details { get; set; }
        public string Title { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}