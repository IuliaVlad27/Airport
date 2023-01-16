using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Airport.Data;
using Airport.Models;

namespace Airport.Pages.Subscribings
{
    public class CreateModel : PageModel
    {
        private readonly Airport.Data.AirportContext _context;

        public CreateModel(Airport.Data.AirportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()

        {
            var bookList = _context.Flight
             .Include(b => b.Airline)
             .Select(x => new
             {
                 x.ID
             });
           //ViewData["FlightID"] = new SelectList(flightList, "ID", "AirlineName");
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Subscribing Subscribing { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Subscribing.Add(Subscribing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
