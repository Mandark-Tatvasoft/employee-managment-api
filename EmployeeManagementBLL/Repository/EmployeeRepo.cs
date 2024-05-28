using EmployeeManagementBLL.Repository.Interface;
using EmployeeManagementDAL.Context;
using EmployeeManagementDAL.Data;
using EmployeeManagementDAL.Models;

namespace EmployeeManagementBLL.Repository;

public class EmployeeRepo : IEmployee
{
    private readonly AppDbContext _context;

    public EmployeeRepo(AppDbContext context)
    {
        _context = context;
    }

    public List<EmployeeModel> GetAllEmployees()
    {
        var list = _context.Employees.ToList();
        var model = new List<EmployeeModel>();

        foreach (var employee in list)
        {
            model.Add(new EmployeeModel { 
                Id = employee.EmployeeId,
                Firstname = employee.Firstname,
                Lastname = employee.Lastname,
                Salary = employee.Salary,
                Designation = employee.Designation
            });
        }

        return model;
    }

    public EmployeeModel GetEmployee(int id)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
        var model = new EmployeeModel{
            Id = employee.EmployeeId,
            Firstname = employee.Firstname,
            Lastname = employee.Lastname,
            Salary = employee.Salary,
            Designation = employee.Designation
        };

        return model;
    }

    public void AddEmployee(EmployeeModel employee)
    {
        var model = new Employee {
            Firstname = employee.Firstname,
            Lastname = employee.Lastname,
            Designation = employee.Designation,
            Salary = employee.Salary,
        };
        
        _context.Employees.Add(model);
        _context.SaveChanges();
    }

    public void EditEmployee(EmployeeModel employee)
    {
        var emp = _context.Employees.FirstOrDefault(e => e.EmployeeId == employee.Id);
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
        _context.SaveChanges();
    }
}