namespace Airport.Models
{
    public class Airline
    {
        public int ID { get; set; }
        public string AirlineName { get; set; }
        public ICollection<Flight>? Flights { get; set; }
    }
}
