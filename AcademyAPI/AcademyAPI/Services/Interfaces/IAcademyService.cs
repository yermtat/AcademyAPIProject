using AcademyAPI.Data.Models;

namespace AcademyAPI.Services.Interfaces;

public interface IAcademyService
{
    public Task<Department> AddDepartmentAsync(string name);
}
