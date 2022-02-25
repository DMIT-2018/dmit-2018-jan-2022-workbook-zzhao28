using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.SamplePages
{
    public class ControlsModel : PageModel
    {
        [TempData]
        public string FeedBack { get; set; }

        [BindProperty]
        public string EmailText { get; set; }
        [BindProperty]
        public string PasswordText { get; set; }
        [BindProperty]
        public string DateTimeText { get; set; }

        [BindProperty]
        public string RadioMeal { get; set; }
        public string[] RadioMeals = new[] {"breakfast", "lunch", "dinner/supper", "snacks" };

        [BindProperty]
        public bool AcceptanceBox { get; set; } // remember value=true on input control

        [BindProperty]
        public string MessageBody { get; set; }

        [BindProperty]
        public int MyRide { get; set; }
        // pretend the collection is coming from the database
        // each row of the collection has two values: selection value; selection text
        // the class SelectionList will be used as the datatype for the collection
        public List<SelectionList> Rides { get; set; }

        [BindProperty]
        public string VacationSpot { get; set; }
        public List<string> VacationSpotList { get; set; }

        [BindProperty]
        public int RangeValue { get; set; }

        public void OnGet()
        {
            PopulateLists();
        }

        public void PopulateLists()
        {
            // pretending that this data comes from the database
            Rides = new List<SelectionList>();
            Rides.Add(new SelectionList() { ValueId = 3, DisplayText = "Bike" });
            Rides.Add(new SelectionList() { ValueId = 5, DisplayText = "Board" });
            Rides.Add(new SelectionList() { ValueId = 2, DisplayText = "Bus" });
            Rides.Add(new SelectionList() { ValueId = 1, DisplayText = "Car" });
            Rides.Add(new SelectionList() { ValueId = 4, DisplayText = "Motorcycle" });
            
            VacationSpotList = new List<string>();
            VacationSpotList.Add("Califonia");
            VacationSpotList.Add("Caribbean");
            VacationSpotList.Add("Cruising");
            VacationSpotList.Add("Europe");
            VacationSpotList.Add("Florida");
            VacationSpotList.Add("Mexico");

        }
        public IActionResult OnPostText()
        {
            // this method is tied to the specific button on the form via
            //  the asp-page-handler attribute.
            // the form of the method name is OnPost then concatenate the
            //  value given to the handler attribute

            FeedBack = $"Email {EmailText}; Password {PasswordText}; Date {DateTimeText}";
            return Page();
        }

        public IActionResult OnPostRadioCheckArea()
        {
            FeedBack = $"Meal {RadioMeal}; Acceptance {AcceptanceBox}; Message {MessageBody}";
            return Page();
        }

        public IActionResult OnPostListSlider()
        {
            FeedBack = $"Ride {MyRide}; Vacation {VacationSpot}; Review Satisfication {RangeValue}";
            PopulateLists();
            return Page();
        }

    }

    public class SelectionList
    {
        public int ValueId { get; set; }
        public string DisplayText { get; set; }
    }
}
