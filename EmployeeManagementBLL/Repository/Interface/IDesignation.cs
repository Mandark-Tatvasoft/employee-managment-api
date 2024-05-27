using EmployeeManagementDAL.Data;

namespace EmployeeManagementBLL.Repository.Interface;

public interface IDesignation
{
    public List<Designation> GetAllDesignations();

    public void EditDesignation(Designation des);

    public void DeleteDesignation(int id);
}
