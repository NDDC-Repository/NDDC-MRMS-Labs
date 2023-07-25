using NddcMrmsLabsLibrary.Databases;
using NddcMrmsLabsLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace NddcMrmsLabsLibrary.Data.Labs
{
    public class SQLLabs : ILabsData
    {
        private readonly ISqlDataAccess db;
        private const string connectionStringName = "SqlDb";

        public SQLLabs(ISqlDataAccess db)
        {
            this.db = db;
        }

        public void AddLab(MyLab lab)
        {
            db.SaveData("Insert Into Laboratories (LabName, RegistrationNo, LabType, Street, State, City, PostCode, CompanyPhone, CompanyEmail, CompanyUrl, ContactName1, ContactAddress1, ContactPhone1, ContactEmail1, ContactName2, ContactAddress2, ContactPhone2, ContactEmail2, Approved, CreatedBy, DateCreated) values(@LabName, @RegistrationNo, @LabType, @Street, @State, @City, @PostCode, @CompanyPhone, @CompanyEmail, @CompanyUrl, @ContactName1, @ContactAddress1, @ContactPhone1, @ContactEmail1, @ContactName2, @ContactAddress2, @ContactPhone2, @ContactEmail2, @Approved, @CreatedBy, @DateCreated)", new { lab.LabName, lab.RegistrationNo, lab.LabType, lab.Street, lab.State, lab.City, lab.PostCode, lab.CompanyPhone, lab.CompanyEmail, lab.CompanyUrl, lab.ContactName1, lab.ContactAddress1, lab.ContactPhone1, lab.ContactEmail1, lab.ContactName2, lab.ContactAddress2, lab.ContactPhone2, lab.ContactEmail2, lab.Approved, lab.CreatedBy, lab.DateCreated }, connectionStringName, false);
        }
    }
}
