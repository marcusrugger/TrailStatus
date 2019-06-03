namespace TrailStatus.Models
{
    public class Trail
    {
        public enum TrailStatus
        {
            Green,
            Yellow,
            Red
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public TrailStatus Status { get; set; }
    }
}