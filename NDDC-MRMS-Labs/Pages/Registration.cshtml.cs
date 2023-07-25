using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLabsLibrary.Data.Labs;
using NddcMrmsLabsLibrary.Model;

namespace NDDC_MRMS_Labs.Pages
{
    public class RegistrationModel : PageModel
    {
        private readonly ILabsData labDb;
        [BindProperty]
        public MyLab Laboratory { get; set; }
        public RegistrationModel(ILabsData labDb)
        {
            this.labDb = labDb;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Laboratory.CreatedBy = "System";
                Laboratory.DateCreated = DateTime.Now;
                Laboratory.Approved = false;
                labDb.AddLab(Laboratory);

                return RedirectToPage("Success");
            }
            else
            {
                return Page();
            }
            
        }
    }
}
