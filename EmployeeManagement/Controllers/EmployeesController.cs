using Microsoft.AspNetCore.Mvc;
using EmployeeManagementDAL.Data;
using EmployeeManagementBLL.Repository.Interface;
using EmployeeManagementDAL.Models;
using Microsoft.AspNetCore.Cors;

namespace EmployeeManagement.Controllers;

[ApiController]
[Route("[controller]")]
[EnableCors()]
public class EmployeesController : ControllerBase
{
    private readonly IEmployee _employee;

    public EmployeesController(IEmployee employee)
    {
        _employee = employee;
    }

    [HttpGet("GetAllEmployees")]
    public IActionResult Get()
    {
        return Ok(_employee.GetAllEmployees());
    }

    [HttpGet("GetEmployee")]
    public IActionResult Get(int id)
    {
        return Ok(_employee.GetEmployee(id));
    }

    [HttpPost("AddEmployee")]
    public IActionResult Post([FromBody] EmployeeModel employee)
    {
        _employee.AddEmployee(employee);    
        return RedirectToAction("Get");
    }

    [HttpPut("UpdateEmployeeDetails")]
    public IActionResult Put([FromBody] Employee employee)
    {
        _employee.EditEmployee(employee);
        return RedirectToAction("Get");
    }

    [HttpDelete("DeleteEmployee")]
    public IActionResult Delete(int id)
    {
        _employee.DeleteEmployee(id);
        return RedirectToAction("Get");
    }
}
