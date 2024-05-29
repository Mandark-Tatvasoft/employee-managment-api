using EmployeeManagementDAL.Data;
using EmployeeManagementDAL.Models;

namespace EmployeeManagementBLL.Repository.Interface;

public interface IDesignation
{
    public List<DesignationModel> GetAllDesignations();
    
    public DesignationModel GetDesignation(int id);

    public void EditDesignation(DesignationModel des);

    public void DeleteDesignation(int id);

    public void AddDesignation(DesignationModel model);

}
