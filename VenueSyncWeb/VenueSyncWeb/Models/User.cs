namespace VenueSyncWeb.Models
{
    public class User
    {
        public int UserID { get; set; } // Primary key, auto-incremented
        public string Username { get; set; } = null!; // Required, e.g., doorman1@VenueSyncOrg.onmicrosoft.com
        public string Role { get; set; } = null!; // Required, e.g., Doorman, Admin
    }
}