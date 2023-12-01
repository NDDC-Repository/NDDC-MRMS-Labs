using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLabsLibrary.Model.Lab
{
    public class MyVitalsModel
    {
        public int SrNo { get; set; }
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string EmployeeCode { get; set; }
        public int Temp { get; set; }
        public int Pulse { get; set; }
        public int Oxygen { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public DateTime DateAdded { get; set; }
        public string AddedBy { get; set; }
    }
}
