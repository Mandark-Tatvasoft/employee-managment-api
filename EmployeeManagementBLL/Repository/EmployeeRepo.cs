using EmployeeManagementBLL.Repository.Interface;
using EmployeeManagementDAL.Context;
using EmployeeManagementDAL.Data;

namespace EmployeeManagementBLL.Repository;

public class EmployeeRepo : IEmployee
{
    private readonly AppDbContext _context;

    public EmployeeRepo(AppDbContext context)
    {
        _context = context;
    }

    public List<Employee> GetAllEmployees()
    {
        return _context.Employees.ToList();
    }

    public Employee GetEmployee(int id)
    {
        return _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
    }

    public void AddEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public void EditEmployee(Employee employee)
    {
        var emp = _context.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
        if(emp != null)
        {
            emp.Firstname = employee.Firstname;
            emp.Lastname = employee.Lastname;
            emp.Salary = employee.Salary;
            emp.Designation = employee.Designation;
            _context.SaveChanges();
        }
    }

    public void DeleteEmployee(int id)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
        _context.Employees.Remove(employee);
    }
}
