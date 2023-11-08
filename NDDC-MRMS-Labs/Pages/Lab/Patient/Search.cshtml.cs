using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLabsLibrary.Data.Employee;

namespace NDDC_MRMS_Labs.Pages.Lab.Patient
{
    public class SearchModel : PageModel
    {
        private readonly IEmployeeData empDb;

        [BindProperty]
        public string EmployeeCode { get; set; }

        public SearchModel(IEmployeeData empDb)
        {
            this.empDb = empDb;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            int id = empDb.GetEmpId(EmployeeCode);
            return RedirectToPage($"Profile", new {empId = id} );
        }
    }
}
