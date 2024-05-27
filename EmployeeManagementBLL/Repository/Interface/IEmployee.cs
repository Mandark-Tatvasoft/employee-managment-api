using EmployeeManagementDAL.Data;
using EmployeeManagementDAL.Models;

namespace EmployeeManagementBLL.Repository.Interface;

public interface IEmployee
{
    public List<EmployeeModel> GetAllEmployees();

    public Employee GetEmployee(int id);

    public void AddEmployee(EmployeeModel employee);

    public void EditEmployee(Employee employee);

    public void DeleteEmployee(int id);
}
