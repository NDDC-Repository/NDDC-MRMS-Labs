using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLabsLibrary.Data.Employee;
using NddcMrmsLabsLibrary.Model.Employee;

namespace NDDC_MRMS_Labs.Pages.Lab.Patient
{
    public class ProfileModel : PageModel
    {
        private readonly IEmployeeData empDb;
        public MyEmployeeModel EmployeeDetails { get; set; }

        public ProfileModel(IEmployeeData empDb)
        {
            this.empDb = empDb;
        }
        public void OnGet(int? empId)
        {
            EmployeeDetails = empDb.GetEmployeeDetails(empId.Value);
        }
    }
}
