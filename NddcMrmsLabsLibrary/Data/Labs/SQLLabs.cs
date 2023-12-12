using NddcMrmsLabsLibrary.Databases;
using NddcMrmsLabsLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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

        public int AddLab(MyLab lab)
        {
            db.SaveData("Insert Into Laboratories (LabName, RegistrationNo, LabType, Street, State, City, PostCode, CompanyPhone, CompanyEmail, CompanyUrl, ContactName1, ContactAddress1, ContactPhone1, ContactEmail1, ContactName2, ContactAddress2, ContactPhone2, ContactEmail2, Approved, CreatedBy, DateCreated) values(@LabName, @RegistrationNo, @LabType, @Street, @State, @City, @PostCode, @CompanyPhone, @CompanyEmail, @CompanyUrl, @ContactName1, @ContactAddress1, @ContactPhone1, @ContactEmail1, @ContactName2, @ContactAddress2, @ContactPhone2, @ContactEmail2, @Approved, @CreatedBy, @DateCreated)", new { lab.LabName, lab.RegistrationNo, lab.LabType, lab.Street, lab.State, lab.City, lab.PostCode, lab.CompanyPhone, lab.CompanyEmail, lab.CompanyUrl, lab.ContactName1, lab.ContactAddress1, lab.ContactPhone1, lab.ContactEmail1, lab.ContactName2, lab.ContactAddress2, lab.ContactPhone2, lab.ContactEmail2, lab.Approved, lab.CreatedBy, lab.DateCreated }, connectionStringName, false);

            int labId = db.LoadData<int, dynamic>("Select Id From Laboratories Where LabName = @LabName", new { LabName = lab.LabName }, connectionStringName, false).FirstOrDefault();

            return labId;

        }
        public void AddLabUser(int labId, string userId, string email, string givenName, string surname, DateTime dateCreated)
        {
            db.SaveData("Insert Into LabUsers (LabId, UserId, Email, GivenName, Surname, DateCreated) values(@LabId, @UserId, @Email, @GivenName, @Surname, @DateCreated)", new { LabID = labId, UserId = userId, Email = email, GivenName = givenName, Surname = surname, DateCreated = dateCreated }, connectionStringName, false);
        }
        public bool UserExistsInLab(string userId)
        {
            userId = db.LoadData<string, dynamic>("Select UserId From LabUsers Where UserId = @UserId", new { UserId = userId }, connectionStringName, false).FirstOrDefault();
            if (string.IsNullOrEmpty(userId))
            {
                return false;
            }
            return true;
        }
        public bool IsLabApproved(string userId)
        {
            int labId = db.LoadData<int, dynamic>("Select LabId From LabUsers Where UserId = @UserId", new { UserId = userId }, connectionStringName, false).FirstOrDefault();

            bool isApproved = db.LoadData<bool, dynamic>("Select Approved From Laboratories Where Id = @LabId", new { LabId = labId }, connectionStringName, false).FirstOrDefault();
            if (isApproved)
            {
                return true;
            }
            return false;
        }
        public int GetLabId(string userId)
        {
            return db.LoadData<int, dynamic>("Select LabId From LabUsers Where UserId = @UserId", new { UserId = userId }, connectionStringName, false).FirstOrDefault();
        }
        public string GetLabName(int Id)
        {
            return db.LoadData<string, dynamic>("Select LabName From Laboratories Where Id = @Id", new { Id = Id }, connectionStringName, false).FirstOrDefault();
        }
        public string GetLabUserFullName(string userId)
        {
            return db.LoadData<string, dynamic>("Select GivenName + ' ' + Surname As FullName From LabUsers Where UserId = @UserId", new { UserId = userId }, connectionStringName, false).FirstOrDefault();
        }
    }
}
