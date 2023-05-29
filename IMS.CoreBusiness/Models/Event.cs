namespace IMS.CoreBusiness.Models
{
    public class Event
    {
        public int Id { get; set; } // Primary Key
        public string EventType { get; set; }

        // Navigation property
        public ICollection<EventDetail> EventDetails { get; set; }
    }
}