using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementDAL.Data;

public partial class Designation
{
    [Key]
    public int DesignationId { get; set; }

    [Column(TypeName = "character varying")]
    public string DesignationName { get; set; } = null!;

    [InverseProperty("DesignationNavigation")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
