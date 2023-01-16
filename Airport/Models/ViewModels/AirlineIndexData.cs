using System.Security.Policy;

namespace Airport.Models.ViewModels
{
    public class AirlineIndexData
    {
        public IEnumerable<Airline> Airlines { get; set; }
        public IEnumerable<Flight> Flights{ get; set; }

    }
}
