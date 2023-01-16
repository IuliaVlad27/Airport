namespace Airport.Models
{
    public class FlightCategory
    {
        public int ID { get; set; }
        public int FlightID { get; set; }
        public Flight Flight { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}