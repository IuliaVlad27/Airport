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

namespace Airport.Pages.Subscribings
{
    public class EditModel : PageModel
    {
        private readonly Airport.Data.AirportContext _context;

        public EditModel(Airport.Data.AirportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Subscribing Subscribing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Subscribing == null)
            {
                return NotFound();
            }

            var subscribing =  await _context.Subscribing.FirstOrDefaultAsync(m => m.ID == id);
            if (subscribing == null)
            {
                return NotFound();
            }
            Subscribing = subscribing;
           ViewData["FlightID"] = new SelectList(_context.Flight, "ID", "ID");
           ViewData["MemberID"] = new SelectList(_context.Member, "ID", "ID");
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

            _context.Attach(Subscribing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscribingExists(Subscribing.ID))
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

        private bool SubscribingExists(int id)
        {
          return _context.Subscribing.Any(e => e.ID == id);
        }
    }
}
