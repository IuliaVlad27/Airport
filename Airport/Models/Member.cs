using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Airport.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string? Name { get; set; }
      
        public string? Adress { get; set; }
        public string Email { get; set; }
       // public string? Phone { get; set; }
        
       
        public ICollection<Subscribing>? Subscribings { get; set; }

    }
}
