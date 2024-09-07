using AcademyAPI.Data.Contexts;
using AcademyAPI.Data.Models.Academy;
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
            if (department == null)
            {
                throw new Exception("Department not found");
            }
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
            if (department == null)
            {
                throw new Exception("Department not found");
            }
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

            if (editedFaculty == null)
            {
                throw new Exception("Faculty not found");
            }

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
            if (faculty == null)
            {
                throw new Exception("Faculty not found");
            }

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

    #region groups

    public async Task<Group> AddGroupAsync(Group group)
    {
        try
        {
            var newGroup = new Group
            {
                Name = group.Name,
                Year = group.Year,
                TeacherId = group.TeacherId,
                FacultyId = group.FacultyId
            };

            await _context.Groups.AddAsync(newGroup);
            await _context.SaveChangesAsync();

            return newGroup;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Group> EditGroupAsync(string id, Group group)
    {
        try
        {
            var existingGroup = await _context.Groups.FindAsync(id);

            if (existingGroup == null)
            {
                throw new Exception("Group not found");
            }

            existingGroup.Name = group.Name;
            existingGroup.Year = group.Year;
            existingGroup.TeacherId = group.TeacherId;
            existingGroup.FacultyId = group.FacultyId;

            await _context.SaveChangesAsync();

            return existingGroup;
        }
        catch
        {
            throw;
        }
    }

    public async Task DeleteGroupAsync(string id)
    {
        try
        {
            var group = await _context.Groups.FindAsync(id);
            if (group == null)
            {
                throw new Exception("Group not found");
            }

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<Group>> GetGroupsAsync()
    {
        try
        {
            return await _context.Groups
                .ToListAsync();
        }
        catch
        {
            throw;
        }
    }

    public async Task<Group> ChangeGroupTeacherAsync(string groupId, string teacherId)
    {
        try
        {
            var group = await _context.Groups.FindAsync(groupId);
            if (group == null)
            {
                throw new Exception("Group not found");
            }

            //var teacher = await _context.Teachers.FindAsync(teacherId);
            //if (teacher == null)
            //{
            //    throw new Exception("Teacher not found");
            //}

            group.TeacherId = teacherId;
            await _context.SaveChangesAsync();

            return group;

        }
        catch
        {
            throw;
        }
    }


    #endregion

    #region students

    public async Task<Student> AddStudentAsync(Student student)
    {
        try
        {
            var newStudent = new Student
            {
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age,
                GroupId = student.GroupId
            };

            await _context.Students.AddAsync(newStudent);
            await _context.SaveChangesAsync();

            return newStudent;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Student> EditStudentAsync(string id, Student student)
    {
        try
        {
            var existingStudent = await _context.Students.FindAsync(id);

            if (existingStudent == null)
            {
                throw new Exception("Student not found");
            }

            existingStudent.Name = student.Name;
            existingStudent.Surname = student.Surname;
            existingStudent.Age = student.Age;
            existingStudent.GroupId = student.GroupId;

            await _context.SaveChangesAsync();

            return existingStudent;
        }
        catch
        {
            throw;
        }
    }

    public async Task DeleteStudentAsync(string id)
    {
        try
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                throw new Exception("Student not found");
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        try
        {
            return await _context.Students
                .ToListAsync();
        }
        catch
        {
            throw;
        }
    }


    #endregion
}
