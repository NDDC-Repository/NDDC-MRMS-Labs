using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NddcMrmsLabsLibrary.Data.Helper;
using NddcMrmsLabsLibrary.Data.Labs;
using NddcMrmsLabsLibrary.Model;
using NddcMrmsLabsLibrary.Model.Helper;

namespace NDDC_MRMS_Labs.Pages
{
    public class RegistrationModel : PageModel
    {
        private readonly ILabsData labDb;
        private readonly IHelperData helpDb;

        [BindProperty]
        public MyLab Laboratory { get; set; }
        public List<State> States { get; set; }
        public RegistrationModel(ILabsData labDb, IHelperData helpDb)
        {
            this.labDb = labDb;
            this.helpDb = helpDb;
        }
        public void OnGet()
        {
            States = helpDb.GetAllStates();
        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                Laboratory.CreatedBy = "System";
                Laboratory.DateCreated = DateTime.Now;
                Laboratory.Approved = false;
                int labId = labDb.AddLab(Laboratory);

                string userId = User.Claims.FirstOrDefault(c => c.Type.Contains("id"))?.Value;
                string email = User.Claims.FirstOrDefault(c => c.Type.Contains("email"))?.Value;
                string givenName = User.Claims.FirstOrDefault(c => c.Type.Contains("givenname"))?.Value;
                string surename = User.Claims.FirstOrDefault(c => c.Type.Contains("surname"))?.Value;

                labDb.AddLabUser(labId, userId, email, givenName, surename, DateTime.Now);

                return RedirectToPage("Success");
            }
            else
            {
                States = helpDb.GetAllStates();
                return Page();
            }
            
        }
    }
}
