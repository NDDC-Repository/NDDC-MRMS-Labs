using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLabsLibrary.Data.Labs;
using System.Security.Claims;

namespace NDDC_MRMS_Labs.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILabsData labDb;

        public IndexModel(ILabsData labDb)
        {
            this.labDb = labDb;
        }

        public IActionResult OnGet()
        {
            //if (User.Claims.FirstOrDefault(c => c.Type.Contains("userisnew"))?.Value == ClaimTypes.)
            //{
            //    return RedirectToPage("Privacy");
            //}
            string userId = User.Claims.FirstOrDefault(c => c.Type.Contains("id"))?.Value;
            if (User.Identity.IsAuthenticated)
            {
                if (labDb.UserExistsInLab(userId))
                {
                    if (labDb.IsLabApproved(userId))
                    {
                        return RedirectToPage("Lab/Index");
                    }
                    //return Page();
                    return RedirectToPage("Error");

                }
                return RedirectToPage("Registration");

            }
            return Page();
        }
    }
}