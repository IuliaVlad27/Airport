using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Airport.Data;
using Airport.Models;

namespace Airport.Pages.Flights
{
    public class IndexModel : PageModel
    {
        private readonly Airport.Data.AirportContext _context;

        public IndexModel(Airport.Data.AirportContext context)
        {
            _context = context;
        }

        public IList<Flight> Flight { get;set; }
        public FlightData FlightD { get; set; }
        public int FlightID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            FlightD = new FlightData();

            FlightD.Flights = await _context.Flight
            .Include(b => b.Airline)
            .Include(b => b.FlightCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Departure)
            .ToListAsync();
            if (id != null)
            {
                FlightID = id.Value;
                Flight flight = FlightD.Flights
                .Where(i => i.ID == id.Value).Single();
                FlightD.Categories = flight.FlightCategories.Select(s => s.Category);
            }
        }


        public async Task OnGetAsync()
        {
            if (_context.Flight != null)
            {
                Flight = await _context.Flight
                    .Include(b => b.Airline)
                    .ToListAsync();
            }
        }
    }
}
