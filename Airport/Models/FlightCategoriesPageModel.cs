using Microsoft.AspNetCore.Mvc.RazorPages;
using Airport.Data;


namespace Airport.Models

{
    public class FlightCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(AirportContext context,
        Flight flight)
        {
            var allCategories = context.Category;
            var flightCategories = new HashSet<int>(
            flight.FlightCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = flightCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateFlightCategories(AirportContext context,
        string[] selectedCategories, Flight flightToUpdate)
        {
            if (selectedCategories == null)
            {
                flightToUpdate.FlightCategories = new List<FlightCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var flightCategories = new HashSet<int>
            (flightToUpdate.FlightCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!flightCategories.Contains(cat.ID))
                    {
                        flightToUpdate.FlightCategories.Add(
                        new FlightCategory
                        {
                            FlightID = flightToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (flightCategories.Contains(cat.ID))
                    {
                        FlightCategory courseToRemove
                        = flightToUpdate
                        .FlightCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    

    }
}
