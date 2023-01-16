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
    public class IndexModel : PageModel
    {
        private readonly Airport.Data.AirportContext _context;

        public IndexModel(Airport.Data.AirportContext context)
        {
            _context = context;
        }

        public IList<Subscribing> Subscribing { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Subscribing != null)
            {
                Subscribing = await _context.Subscribing
                .Include(s => s.Flights)
                .ThenInclude(b => b.Airline)
                .Include(s => s.Member).ToListAsync();
            }
        }
    }
}
