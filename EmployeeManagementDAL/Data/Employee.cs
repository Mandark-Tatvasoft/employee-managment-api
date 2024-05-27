using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementDAL.Data;

public partial class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [Column(TypeName = "character varying")]
    public string? Firstname { get; set; }

    [Column(TypeName = "character varying")]
    public string? Lastname { get; set; }

    public int? Designation { get; set; }

    public int? Salary { get; set; }

    [ForeignKey("Designation")]
    [InverseProperty("Employees")]
    public virtual Designation? DesignationNavigation { get; set; }
}
