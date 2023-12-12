using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLabsLibrary.Model.Lab
{
    public class MyRequestModel
    {
        public int Id { get; set; }
        public int InvestigationId { get; set; }
        public string UserName { get; set; }
        public string RequestedBy { get; set; }
        public string RequestedFrom { get; set; }
        public string RequestType { get; set; }
        public int ExaminationYear { get; set; }
        public int ExaminationCategoryId { get; set; }
        public int ExaminationTypeId { get; set; }
        public string Result { get; set; }
        public string ResultUnit { get; set; }
        public string RefRange { get; set; }
        public string Flag { get; set; }
        public DateTime DateConducted { get; set; }
        public DateTime TimeReportedOn { get; set; }
        public string Summary { get; set; }
        public DateTime DateRequested { get; set; }
        public string Status { get; set; }
    }
}
