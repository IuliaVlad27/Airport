using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airport.Data;
using Airport.Models;

namespace Airport.Pages.Flights
{
    public class EditModel : FlightCategoriesPageModel
    {
        private readonly Airport.Data.AirportContext _context;

        public EditModel(Airport.Data.AirportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Flight Flight { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Flight == null)
            {
                return NotFound();
            }
            Flight = await _context.Flight
                .Include(b => b.Airline)
                 .Include(b => b.FlightCategories).ThenInclude(b => b.Category)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.ID == id);


            var flight = await _context.Flight.FirstOrDefaultAsync(m => m.ID == id);
            if (flight == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Flight);

            Flight = flight;
            ViewData["AirlineID"] = new SelectList(_context.Set<Airline>(), "ID",
               "AirlineName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            
 {
                if (id == null)
                {
                    return NotFound();
                }
               
                var flightToUpdate = await _context.Flight
                .Include(i => i.Airline)
                .Include(i => i.FlightCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);
                if (flightToUpdate == null)
                {
                    return NotFound();
                }
                if (await TryUpdateModelAsync<Flight>(
                flightToUpdate,"Flight",
                i => i.Departure,
                i => i.Price, i => i.FlightDate, i => i.AirlineID))
                {
                    UpdateFlightCategories(_context, selectedCategories, flightToUpdate);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                UpdateFlightCategories(_context, selectedCategories, flightToUpdate);
                PopulateAssignedCategoryData(_context, flightToUpdate);
                return Page();
            }
        }

    }
}
