namespace VenueSyncWeb.Models
{
    public class Venue
    {
        public int VenueID { get; set; }
        public string VenueName { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string VenueType { get; set; } = null!;
    }
}