using NddcMrmsLabsLibrary.Databases;
using NddcMrmsLabsLibrary.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLabsLibrary.Data.Employee
{
    public class SqlEmployee : IEmployeeData
    {
        private const string connectionStringName = "PayrollDb";
        private readonly ISqlDataAccess db;

        public SqlEmployee(ISqlDataAccess db)
        {
            this.db = db;
        }

        public bool EmployeeExists(string employeeCode)
        {
            employeeCode = db.LoadData<string, dynamic>("Select EmployeeCode From Employees Where EmployeeCode = @EmployeeCode", new { EmployeeCode = employeeCode }, connectionStringName, false).FirstOrDefault();
            if (string.IsNullOrEmpty(employeeCode))
            {
                return false;
            }
            return true;
        }
        public MyEmployeeModel GetEmployeeDetails(int empId)
        {
            return db.LoadData<MyEmployeeModel, dynamic>("Select EmployeeCode, FirstName, LastName, Gender, MaritalStatus, PayPoint, DateOfBirth, Email From Employees Where Id = @Id", new { Id = empId }, connectionStringName, false).FirstOrDefault();
        }
        public int GetEmpId(string employeeCode)
        {
            return db.LoadData<int, dynamic>("Select Id From Employees Where EmployeeCode = @EmployeeCode", new { EmployeeCode = employeeCode }, connectionStringName, false).FirstOrDefault();
        }
    }
}
