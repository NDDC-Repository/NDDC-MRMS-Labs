using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLabsLibrary.Data.Employee;
using NddcMrmsLabsLibrary.Data.Helper;
using NddcMrmsLabsLibrary.Data.Labs;
using NddcMrmsLabsLibrary.Model.Employee;

namespace NDDC_MRMS_Labs.Pages.Lab.Patient
{
    public class ProfileModel : PageModel
    {
        private readonly IEmployeeData empDb;
        private readonly ILabsData labDb;
        private readonly IHelperData helpDb;

        public MyEmployeeModel EmployeeDetails { get; set; }
        public int EmpId { get; set; }
        public string UserId { get; set; }
        public int LabId { get; set; }

        public ProfileModel(IEmployeeData empDb, ILabsData labDb)
        {
            this.empDb = empDb;
            this.labDb = labDb;
        }
        public void OnGet(int? empId)
        {
            UserId = User.Claims.FirstOrDefault(c => c.Type.Contains("id"))?.Value;
            LabId = labDb.GetLabId(UserId);

            EmpId = empId.Value;
            EmployeeDetails = empDb.GetEmployeeDetails(empId.Value);
        }
    }
}
