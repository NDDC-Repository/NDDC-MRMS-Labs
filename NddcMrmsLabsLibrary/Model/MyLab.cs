using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLabsLibrary.Model
{
    public class MyLab
    {
        public int Id { get; set; }
        public string LabName { get; set; }
        public string RegistrationNo { get; set; }
        public string LabType { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyUrl { get; set; }
        public string ContactName1 { get; set; }
        public string ContactAddress1 { get; set; }
        public string ContactPhone1 { get; set; }
        public string ContactEmail1 { get; set; }
        public string ContactName2 { get; set; }
        public string ContactAddress2 { get; set; }
        public string ContactPhone2 { get; set; }
        public string ContactEmail2 { get; set; }
        public bool Approved { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
