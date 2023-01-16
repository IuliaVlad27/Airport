using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Airport.Models
{
    public class Flight
    {
        public int ID { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        [Column(TypeName = "decimal(6, 2)")]

        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime FlightDate { get; set; }
        public int? AirlineID { get; set; }
        public Airline? Airline { get; set; }
        public ICollection<FlightCategory>? FlightCategories { get; set; }


    }
}
