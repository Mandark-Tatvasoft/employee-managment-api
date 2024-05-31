using EmployeeManagementBLL.Repository.Interface;
using EmployeeManagementDAL.Context;
using EmployeeManagementDAL.Data;
using EmployeeManagementDAL.Models;

namespace EmployeeManagementBLL.Repository;

public class DesignatonRepo : IDesignation
{
    private readonly AppDbContext _context;

    public DesignatonRepo(AppDbContext context)
    {
        _context = context;
    }

    public List<DesignationModel> GetAllDesignations()
    {
        var model = new List<DesignationModel>();
        var list = _context.Designations.ToList();
        if (list != null)
        {
            foreach (var item in list)
            {
                model.Add(new DesignationModel
                {
                    DesignationId = item.DesignationId,
                    DesignationName = item.DesignationName
                });
            }
        }

        return model;
    }

    public DesignationModel GetDesignation(int id)
    {
        var designation = _context.Designations.FirstOrDefault(d => d.DesignationId == id);
        var model = new DesignationModel();
        if (designation != null)
        {
            model.DesignationId = designation.DesignationId;
            model.DesignationName = designation.DesignationName;
        }

        return model;
    }

    public void DeleteDesignation(int id)
    {
        var designation = _context.Designations.FirstOrDefault(d => d.DesignationId == id);
        if (designation != null)
        {
            try
            {
                _context.Designations.Remove(designation);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    public void EditDesignation(DesignationModel des)
    {
        var designation = _context.Designations.FirstOrDefault(d => d.DesignationId == des.DesignationId);
        if (designation != null)
        {
            designation.DesignationName = des.DesignationName;
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

    public void AddDesignation(DesignationModel model)
    {
        var newDesignation = new Designation
        {
            DesignationName = model.DesignationName
        };
        try
        {
            _context.Designations.Add(newDesignation);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
