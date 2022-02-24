using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.SamplePages
{
    public class BasicsModel : PageModel
    {
        // basically this is an object, treat it as such

        // data fields
        public string MyName;

        // properties

        // constructors

        // behaviours (aka methods)
        public void OnGet()
        {
            // executes in response to a Get request from the browser
            // when the page is first accessed, it issues a Get request
            // when the page is refreshed, WITHOUT a Post, it issues a Get request
            // when the page is retrieved in response to a form POST using RedirectToPage()
            // IF NOT RedirectToPage() is used on the POST, there is NO Get request issued
            Random rnd = new Random();
            int oddeven = rnd.Next(0,25);
            if(oddeven % 2 == 0)
            {
                MyName = $"Don is even ({oddeven})";
            }
            else
            {
                MyName = null;
            }
        }
    }
}
