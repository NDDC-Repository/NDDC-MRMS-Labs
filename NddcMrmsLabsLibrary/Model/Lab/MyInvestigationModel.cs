using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLabsLibrary.Model.Lab
{
    public class MyInvestigationModel
    {
        public int SrNo { get; set; }
        public int Id { get; set; }
        public int ExaminationYear { get; set; }
        public int EmpId { get; set; }
        public string TestDescription { get; set; }
		public int ExaminationCategoryId { get; set; }
		public int ExaminationTypeId { get; set; }
		public string TestResult { get; set; }
		public string ResultUnit { get; set; }
		public string RefRange { get; set; }
		public string Flag { get; set; }
		public DateTime DateConducted { get; set; } = DateTime.Now;
		public DateTime TimeReported { get; set; } = DateTime.Now;
		public string ConductedBy { get; set; }
		public string Summary { get; set; }

        public string ExaminationType { get; set; }
        public string AddedBy { get; set; }
        public int LabId { get; set; }



    }
}
