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
        var list = _context.Employees.OrderBy(e => e.EmployeeId).ToList();
        var model = new List<EmployeeModel>();

        if (list.Count > 0)
        {
            foreach (var employee in list)
            {
                model.Add(new EmployeeModel
                {
                    Id = employee.EmployeeId,
                    Firstname = employee.Firstname,
                    Lastname = employee.Lastname,
                    Salary = employee.Salary,
                    Designation = employee.Designation
                });
            }
        }

        return model;
    }

    public EmployeeModel GetEmployee(int id)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
        var model = new EmployeeModel();
        if (employee != null)
        {
            model.Id = employee.EmployeeId;
            model.Firstname = employee.Firstname;
            model.Lastname = employee.Lastname;
            model.Salary = employee.Salary;
            model.Designation = employee.Designation;
        }
        return model;
    }

    public void AddEmployee(EmployeeModel employee)
    {
        var model = new Employee
        {
            Firstname = employee.Firstname,
            Lastname = employee.Lastname,
            Designation = employee.Designation,
            Salary = employee.Salary,
        };
        try
        {
            _context.Employees.Add(model);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    public void EditEmployee(EmployeeModel employee)
    {
        var emp = _context.Employees.FirstOrDefault(e => e.EmployeeId == employee.Id);
        if (emp != null)
        {
            emp.Firstname = employee.Firstname;
            emp.Lastname = employee.Lastname;
            emp.Salary = employee.Salary;
            emp.Designation = employee.Designation;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    public void DeleteEmployee(int id)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
        if (employee != null)
        {
            try
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}