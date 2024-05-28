using EmployeeManagementDAL.Data;
using EmployeeManagementDAL.Models;

namespace EmployeeManagementBLL.Repository.Interface;

public interface IEmployee
{
    public List<EmployeeModel> GetAllEmployees();

    public EmployeeModel GetEmployee(int id);

    public void AddEmployee(EmployeeModel employee);

    public void EditEmployee(EmployeeModel employee);

    public void DeleteEmployee(int id);
}
