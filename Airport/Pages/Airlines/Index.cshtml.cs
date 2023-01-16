using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Airport.Data;
using Airport.Models;
using System.Security.Policy;
using Airport.Models.ViewModels;

namespace Airport.Pages.Airlines
{
    public class IndexModel : PageModel
    {
        private readonly Airport.Data.AirportContext _context;

        public IndexModel(Airport.Data.AirportContext context)
        {
            _context = context;
        }

        public IList<Airline> Airline { get; set; } = default!;

        public AirlineIndexData AirlineData { get; set; }
        public int AirlineID { get; set; }
        public int FlightID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            AirlineData = new AirlineIndexData();
            AirlineData.Airlines = await _context.Airline
            .Include(i => i.Flights)
            //.ThenInclude(c => c.Author)
            .OrderBy(i => i.AirlineName)
            .ToListAsync();
            if (id != null)
            {
                AirlineID = id.Value;
                Airline airline = AirlineData.Airlines
                .Where(i => i.ID == id.Value).Single();
                AirlineData.Flights = airline.Flights;
            }

        }
    }
}
