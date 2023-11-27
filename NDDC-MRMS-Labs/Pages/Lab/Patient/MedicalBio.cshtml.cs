using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcMrmsLabsLibrary.Data.Employee;

namespace NDDC_MRMS_Labs.Pages.Lab.Patient
{
    public class MedicalBioModel : PageModel
    {
        private readonly IEmployeeData empDb;

        public int EmpId { get; set; }
        public MedicalBioModel(IEmployeeData empDb)
        {
            this.empDb = empDb;
        }
        public void OnGet(int? empIdd)
        {
            EmpId = empIdd.Value;
        }
    }
}
