namespace VenueSyncWeb.Models
{
    public class Venue
    {
        public int VenueID { get; set; } // Primary key, auto-incremented
        public string VenueName { get; set; } = null!; // Required, e.g., Central Library
        public string Location { get; set; } = null!; // Required, e.g., Stevenage
    }
}