using AcademyAPI.Data.Contexts;
using AcademyAPI.Data.Models;
using AcademyAPI.Services.Interfaces;

namespace AcademyAPI.Services.Classes;

public class AcademyService : IAcademyService
{
    private readonly AcademyContext _context;

    public async Task<Department> AddDepartmentAsync(string name)
    {
        try
        {
            var department = new Department
            {
                Name = name,
            };

            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();

            return department;
        }
        catch {
            throw;
        }   
    }
}
