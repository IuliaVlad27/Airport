namespace Airport.Models
{
    public class FlightData
    {
        public IEnumerable<Flight> Flights { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<FlightCategory> FlightCategories { get; set; }
    }
}
