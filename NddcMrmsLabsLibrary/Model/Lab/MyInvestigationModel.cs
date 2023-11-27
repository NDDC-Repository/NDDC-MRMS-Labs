using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLabsLibrary.Model.Lab
{
    public class MyInvestigationModel
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string TestDescription { get; set; }
        public string ConductedBy { get; set; }
        public DateTime DateConducted { get; set; }
    }
}
