using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLabsLibrary.Model
{
    public class MyLab
    {
        public int Id { get; set; }
        [Required]
        public string LabName { get; set; }
        public string RegistrationNo { get; set; }
        public string LabType { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        public string PostCode { get; set; }
        [Required]
        public string CompanyPhone { get; set; }
        [Required]
        public string CompanyEmail { get; set; }
        public string CompanyUrl { get; set; }
        [Required]
        public string ContactName1 { get; set; }
        [Required]
        public string ContactAddress1 { get; set; }
        [Required]
        public string ContactPhone1 { get; set; }
        [Required]
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
