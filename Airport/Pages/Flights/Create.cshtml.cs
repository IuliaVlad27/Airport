using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Airport.Data;
using Airport.Models;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore;
using Airport.Models;

namespace Airport.Pages.Flights
{
    public class CreateModel : FlightCategoriesPageModel
    {
        private readonly Airport.Data.AirportContext _context;

        public CreateModel(Airport.Data.AirportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            ViewData["AirlineID"] = new SelectList(_context.Set<Airline>(), "ID",
           "AirlineName");

            var flight = new Flight();
            flight.FlightCategories = new List<FlightCategory>();
            PopulateAssignedCategoryData(_context, flight);

            return Page();
        }

        [BindProperty]

        public Flight Flight { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Flight();
            if (selectedCategories != null)
            {
                newBook.FlightCategories = new List<FlightCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new FlightCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.FlightCategories.Add(catToAdd);
                }
            }
            Flight.FlightCategories = newBook.FlightCategories;
            _context.Flight.Add(Flight);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedCategoryData(_context, Flight);

            return Page();
        }
           
    }
}



   

