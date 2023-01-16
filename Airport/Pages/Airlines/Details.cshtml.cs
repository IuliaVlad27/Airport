using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Airport.Data;
using Airport.Models;

namespace Airport.Pages.Airlines
{
    public class DetailsModel : PageModel
    {
        private readonly Airport.Data.AirportContext _context;

        public DetailsModel(Airport.Data.AirportContext context)
        {
            _context = context;
        }

      public Airline Airline { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Airline == null)
            {
                return NotFound();
            }

            var airline = await _context.Airline.FirstOrDefaultAsync(m => m.ID == id);
            if (airline == null)
            {
                return NotFound();
            }
            else 
            {
                Airline = airline;
            }
            return Page();
        }
    }
}
