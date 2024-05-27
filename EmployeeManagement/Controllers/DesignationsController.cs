using EmployeeManagementBLL.Repository.Interface;
using EmployeeManagementDAL.Data;
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
        return Ok(_designation.GetAllDesignations());
    }

    [HttpPut("EditDesignation")]
    public IActionResult Put([FromBody] Designation designation)
    {
        _designation.EditDesignation(designation);
        return RedirectToAction("Get");
    }

    [HttpDelete("DeleteDesignation")]
    public IActionResult Delete(int id)
    {
        _designation.DeleteDesignation(id);
        return RedirectToAction("Get");
    }
}
