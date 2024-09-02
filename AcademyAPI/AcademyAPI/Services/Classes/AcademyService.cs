using AcademyAPI.Data.Contexts;
using AcademyAPI.Data.Models;
using AcademyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AcademyAPI.Services.Classes;

public class AcademyService : IAcademyService
{
    private readonly AcademyContext _context;

    public AcademyService(AcademyContext context)
    {
        _context = context;
    }

    #region departments
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

    public async Task EditDepartmentAsync(string id, string name)
    {
        try
        {
            var department = await _context.Departments.FindAsync(id);
            department.Name = name;

            await _context.SaveChangesAsync();

        }
        catch
        {
            throw;
        }
    }

    public async Task DeleteDepartmentAsync(string id)
    {
        try
        {
            var department = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(department);

            await _context.SaveChangesAsync();
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<Department>> GetDepartmentsAsync()
    {
        return await _context.Departments.ToListAsync();
    }

    #endregion

    #region faculties
    public async Task<Faculty> AddFacultyAsync(Faculty faculty)
    {
        try
        {
            var newFaculty = new Faculty
            {
                Name = faculty.Name,
                DepartmentsNumber = faculty.DepartmentsNumber
            };

            await _context.Faculties.AddAsync(newFaculty);
            await _context.SaveChangesAsync();

            return newFaculty;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Faculty> EditFacultyAsync(string id, Faculty faculty)
    {
        try
        {
            var editedFaculty = await _context.Faculties.FindAsync(id);

            editedFaculty.Name = faculty.Name;
            editedFaculty.DepartmentsNumber = faculty.DepartmentsNumber;

            await _context.SaveChangesAsync();

            return editedFaculty;
        }
        catch
        {
            throw;
        }
    }

    public async Task DeleteFacultytAsync(string id)
    {
        try
        {
            var faculty = await _context.Faculties.FindAsync(id);
            _context.Faculties.Remove(faculty);
            await _context.SaveChangesAsync();
        }
        catch 
        {
            throw;
        }
    }

    public async Task<List<Faculty>> GetFacultiesAsync()
    {
        return await _context.Faculties.ToListAsync();
    }


    #endregion

    #region teachers

    public async Task<Teacher> AddTeacherAsync(Teacher teacher)
    {
        try
        {
            var newTeacher = new Teacher
            {
                Name = teacher.Name,
                Surname = teacher.Surname,
                Subject = teacher.Subject,
                DepartmentId = teacher.DepartmentId,
                WorkHours = teacher.WorkHours,
            };

            await _context.Teachers.AddAsync(newTeacher);
            await _context.SaveChangesAsync();

            return newTeacher;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Teacher> EditTeacherAsync(string id, Teacher teacher)
    {
        try
        {
            var existingTeacher = await _context.Teachers.FindAsync(id);

            if (existingTeacher == null)
            {
                throw new Exception("Teacher not found");
            }

            existingTeacher.Name = teacher.Name;
            existingTeacher.Surname = teacher.Surname;
            existingTeacher.Subject = teacher.Subject;
            existingTeacher.DepartmentId = teacher.DepartmentId;
            existingTeacher.WorkHours = teacher.WorkHours;

            await _context.SaveChangesAsync();

            return existingTeacher;
        }
        catch
        {
            throw;
        }
    }

    public async Task DeleteTeacherAsync(string id)
    {
        try
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                throw new Exception("Teacher not found");
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<Teacher>> GetTeachersAsync()
    {
        try
        {
            return await _context.Teachers.ToListAsync();
        }
        catch
        {
            throw;
        }
    }


    #endregion
}
