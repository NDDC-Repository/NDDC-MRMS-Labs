using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLabsLibrary.Model.Lab
{
    public class MyDocumentModel
    {
        public int Id { get; set; }
        public int MyEmpId { get; set; }
        public string EmployeeCode { get; set; }
        public string DocTitile { get; set; }
        public string DocDesc { get; set; }
        public string AddedBy { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
