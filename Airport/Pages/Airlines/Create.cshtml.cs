using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Airport.Data;
using Airport.Models;

namespace Airport.Pages.Airlines
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

            
            return Page();
        }

        [BindProperty]
        public Airline Airline { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Airline.Add(Airline);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
