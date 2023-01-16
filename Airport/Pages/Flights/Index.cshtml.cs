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

        public IList<Flight> Flight { get; set; }
        public FlightData FlightD { get; set; }
        public int FlightID { get; set; }
        public int CategoryID { get; set; }

        public string DepartureSort { get; set; }
        public string ArrivalSort { get; set; }
        public string CurrentFilter { get; set; }


        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            FlightD = new FlightData();
            DepartureSort = String.IsNullOrEmpty(sortOrder) ? "departure_desc" : "";
            ArrivalSort = String.IsNullOrEmpty(sortOrder) ? "arrival_desc" : "";

            CurrentFilter = searchString;



            FlightD.Flights = await _context.Flight
            .Include(b => b.Airline)
            .Include(b => b.FlightCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Departure)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                 FlightD.Flights = FlightD.Flights.Where(s => s.Arrival.Contains(searchString)

                 ||s.Arrival.Contains(searchString) 
                 || s.Departure.Contains(searchString));

                if (id != null)
                {
                    FlightID = id.Value;
                    Flight flight = FlightD.Flights
                    .Where(i => i.ID == id.Value).Single();
                    FlightD.Categories = flight.FlightCategories.Select(s => s.Category);
                }
                switch (sortOrder)
                {
                    case "departure_desc":
                        FlightD.Flights = FlightD.Flights.OrderByDescending(s =>
                       s.Departure);
                        break;
                    case "arrival_desc":
                        FlightD.Flights = FlightD.Flights.OrderByDescending(s =>
                       s.Arrival);
                        break;

                }


                
            }
        }
        public async Task OnGetAsync(int? categoryID)
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

