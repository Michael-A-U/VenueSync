using System.ComponentModel.DataAnnotations;

namespace VenueSyncWeb.Models
{
    public class Headcount
    {
        public int HeadcountID { get; set; } // Primary key, auto-incremented
        [Required] // Ensures a venue is selected
        public int VenueID { get; set; } // Foreign key to Venues
        [Required] // Ensures a user is associated
        public int UserID { get; set; } // Foreign key to Users
        [Required(ErrorMessage = "Headcount is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Headcount must be non-negative")]
        public int Count { get; set; } // Headcount value
        public DateTime Timestamp { get; set; } // Auto-set on submission
        [StringLength(500)] // Limits notes to 500 characters
        public string? Notes { get; set; } // Optional notes
        public Venue? Venue { get; set; } // Navigation property for EF Core
        public User? User { get; set; } // Navigation property for EF Core
    }
}