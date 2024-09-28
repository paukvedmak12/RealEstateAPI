namespace RealEstateAPI.Models
{
    public class Resident
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int ApartmentId { get; set; } // Foreign key to Apartment
        public Apartment Apartment { get; set; } // Navigation property
    }
}
