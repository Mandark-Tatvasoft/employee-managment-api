using EmployeeManagementBLL.Repository.Interface;
using EmployeeManagementDAL.Data;
using EmployeeManagementDAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class DesignationsController : ControllerBase
{
    private readonly IDesignation _designation;

    public DesignationsController(IDesignation designation)
    {
        _designation = designation;
    }

    [HttpGet("GetAllDesignations")]
    public IActionResult Get()
    {
        var model = new ResponseModel<List<DesignationModel>>();
        var data = _designation.GetAllDesignations();

        if (data.Count > 0)
        {
            model.Data = data;
            model.IsSuccess = true;
            return Ok(model);
        }
        else
        {
            model.IsSuccess = false;
            model.Message = "No designation found!";
            return NotFound(model);
        }
    }

    [HttpGet("GetDesignation")]
    public IActionResult Get(int id)
    {
        var model = new ResponseModel<DesignationModel>();
        var data = _designation.GetDesignation(id);
        if (data.DesignationId != 0)
        {
            model.Data = data;
            model.IsSuccess = true;
            return Ok(model);
        }
        else
        {
            model.IsSuccess = false;
            model.Message = "No such record exists!";
            return NotFound(model);
        }
    }

    [HttpPut("EditDesignation")]
    public IActionResult Put([FromBody] DesignationModel designation)
    {
        _designation.EditDesignation(designation);
        return Ok();
    }

    [HttpDelete("DeleteDesignation")]
    public IActionResult Delete(int id)
    {
        _designation.DeleteDesignation(id);
        return Ok();
    }

    [HttpPost("AddDesignation")]
    public IActionResult Post(DesignationModel model)
    {
        _designation.AddDesignation(model);
        return Ok();
    }
}
