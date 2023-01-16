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
    public class DetailsModel : PageModel
    {
        private readonly Airport.Data.AirportContext _context;

        public DetailsModel(Airport.Data.AirportContext context)
        {
            _context = context;
        }

      public Flight Flight { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Flight == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight.FirstOrDefaultAsync(m => m.ID == id);
            if (flight == null)
            {
                return NotFound();
            }
            else 
            {
                Flight = flight;
            }
            return Page();
        }
    }
}
