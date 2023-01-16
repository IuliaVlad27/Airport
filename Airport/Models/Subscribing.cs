using System.ComponentModel.DataAnnotations;

namespace Airport.Models
{
    public class Subscribing
    {
        public int ID { get; set; }
        public int? MemberID { get; set; }
        public Member? Member { get; set; }
        public int? FlightID { get; set; }
        public Flight? Flight { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
    }
}
