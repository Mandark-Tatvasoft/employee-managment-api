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
        var model = new ResponseModel<List<EmployeeModel>>();
        var data = _employee.GetAllEmployees();
        if(data.Count > 0){
            model.Data = data;
            model.IsSuccess = true;
            return Ok(model);
        }
        else
        {
            model.IsSuccess = false;
            model.Message = "No Employees Found";
            return NotFound(model);
        }
        
    }

    [HttpGet("GetEmployee")]
    public IActionResult Get(int id)
    {
        var model = new ResponseModel<EmployeeModel>();
        var data = _employee.GetEmployee(id);
        if(data.Id != 0){
            model.Data = data;
            model.IsSuccess = true;
            return Ok(model);
        }
        else{
            model.IsSuccess = false;
            model.Message = "Data not found!";
            return Ok(model);
        }
    }

    [HttpPost("AddEmployee")]
    public IActionResult Post([FromBody] EmployeeModel employee)
    {
        _employee.AddEmployee(employee);
        return Ok();
    }

    [HttpPut("UpdateEmployeeDetails")]
    public IActionResult Put([FromBody] EmployeeModel employee)
    {
        _employee.EditEmployee(employee);
        return Ok();
    }

    [HttpDelete("DeleteEmployee")]
    public IActionResult Delete(int id)
    {
        _employee.DeleteEmployee(id);
        return Ok();
    }
}
