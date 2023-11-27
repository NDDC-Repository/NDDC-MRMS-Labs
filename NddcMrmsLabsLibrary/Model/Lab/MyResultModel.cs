using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLabsLibrary.Model.Lab
{
    public class MyResultModel
    {
        public int Id { get; set; }
        public int InvestigationId { get; set; }
        public string ProcessCategory { get; set; }
        public string ProcessName { get; set; }
        public string TestResult { get; set; }
        public string ResultUnit { get; set; }
        public string Range { get; set; }
        public string Flag { get; set; }
        public DateTime DateConducted { get; set; }
        public DateTime TimeReported { get; set; }
        public string ConductedBy { get; set; }
        public string Summary { get; set; }
    }
}
