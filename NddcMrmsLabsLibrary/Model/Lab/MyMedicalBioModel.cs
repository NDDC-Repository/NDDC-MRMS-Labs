using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLabsLibrary.Model.Lab
{
    public class MyMedicalBioModel
    {
        public int Id { get; set; } = 0;
        public int EmpId { get; set; } = 0;
        public string EmployeeCode { get; set; } = "";
        public double Height { get; set; } = 0.00;
        public string BloodType { get; set; } = "None";
        public string BloodGroup { get; set; } = "None";
        public string Genotype { get; set; } = "None";
        public int Weight { get; set; } = 0;
        public double BMI { get; set; } = 0.00;
        public Boolean Disabilities { get; set; } = false;
        public string AddedBy { get; set; } = "";
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
