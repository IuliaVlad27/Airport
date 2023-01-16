using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Airport.Data;
using Airport.Models;

namespace Airport.Pages.Subscribings
{
    public class DetailsModel : PageModel
    {
        private readonly Airport.Data.AirportContext _context;

        public DetailsModel(Airport.Data.AirportContext context)
        {
            _context = context;
        }

      public Subscribing Subscribing { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Subscribing == null)
            {
                return NotFound();
            }

            var subscribing = await _context.Subscribing.FirstOrDefaultAsync(m => m.ID == id);
            if (subscribing == null)
            {
                return NotFound();
            }
            else 
            {
                Subscribing = subscribing;
            }
            return Page();
        }
    }
}
