using NddcMrmsLabsLibrary.Model.Employee;

namespace NddcMrmsLabsLibrary.Data.Employee
{
    public interface IEmployeeData
    {
        int GetEmpId(string employeeCode);
        bool EmployeeExists(string employeeCode);
        MyEmployeeModel GetEmployeeDetails(int empId);
    }
}