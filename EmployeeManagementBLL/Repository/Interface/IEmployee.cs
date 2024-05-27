using EmployeeManagementDAL.Data;

namespace EmployeeManagementBLL.Repository.Interface;

public interface IEmployee
{
    public List<Employee> GetAllEmployees();

    public Employee GetEmployee(int id);

    public void AddEmployee(Employee employee);

    public void EditEmployee(Employee employee);

    public void DeleteEmployee(int id);
}
