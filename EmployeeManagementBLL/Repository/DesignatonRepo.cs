using EmployeeManagementBLL.Repository.Interface;
using EmployeeManagementDAL.Context;
using EmployeeManagementDAL.Data;

namespace EmployeeManagementBLL.Repository;

public class DesignatonRepo : IDesignation
{
    private readonly AppDbContext _context;

    public DesignatonRepo(AppDbContext context)
    {
        _context = context;
    }

    public List<Designation> GetAllDesignations()
    {
        return _context.Designations.ToList();
    }
    public void DeleteDesignation(int id)
    {
        var designation = _context.Designations.FirstOrDefault(d => d.DesignationId == id);
        if(designation != null)
        {
            _context.Designations.Remove(designation);
        }
    }

    public void EditDesignation(Designation des)
    {
        var designation = _context.Designations.FirstOrDefault(d => d.DesignationId == des.DesignationId);
        designation.DesignationName = des.DesignationName;
        _context.SaveChanges();
    }
}
