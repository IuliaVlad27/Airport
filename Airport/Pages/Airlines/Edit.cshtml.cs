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

namespace Airport.Pages.Airlines
{
    public class EditModel : PageModel
    {
        private readonly Airport.Data.AirportContext _context;

        public EditModel(Airport.Data.AirportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Airline Airline { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Airline == null)
            {
                return NotFound();
            }

            var airline =  await _context.Airline.FirstOrDefaultAsync(m => m.ID == id);
            if (airline == null)
            {
                return NotFound();
            }
            Airline = airline;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Airline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirlineExists(Airline.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AirlineExists(int id)
        {
          return _context.Airline.Any(e => e.ID == id);
        }
    }
}
