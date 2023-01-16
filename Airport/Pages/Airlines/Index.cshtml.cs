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
    public class IndexModel : PageModel
    {
        private readonly Airport.Data.AirportContext _context;

        public IndexModel(Airport.Data.AirportContext context)
        {
            _context = context;
        }

        public IList<Airline> Airline { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Airline != null)
            {
                Airline = await _context.Airline.ToListAsync();
            }
        }
    }
}
