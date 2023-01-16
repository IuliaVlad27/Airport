namespace Airport.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<FlightCategory>? FlightCategories { get; set; }
    }
}
