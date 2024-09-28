namespace RealEstateAPI.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Floor { get; set; }
        public int RoomsCount { get; set; }
        public int ResidentsCount { get; set; }
        public double TotalArea { get; set; }
        public double LivingArea { get; set; }
        public int HouseId { get; set; } // Foreign key to House
        public House House { get; set; } // Navigation property
    }
}
