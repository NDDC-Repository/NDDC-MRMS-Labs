using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLabsLibrary.Model.Lab
{
    public class MyMedicalReportModel
    {
        public int Id { get; set; }
        public int SrNo { get; set; }
        public int EmpId { get; set; }
        public string ReportTitle { get; set; }
        public int ExaminationYear { get; set; }
        public string FileName { get; set; }
        public string AddedBy { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
