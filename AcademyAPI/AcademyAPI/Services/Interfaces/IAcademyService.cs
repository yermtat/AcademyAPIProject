using AcademyAPI.Data.Models;

namespace AcademyAPI.Services.Interfaces;

public interface IAcademyService
{

    public Task<Department> AddDepartmentAsync(string name);

    public Task EditDepartmentAsync(string id, string name);
    public Task DeleteDepartmentAsync(string id);
    public Task<List<Department>> GetDepartmentsAsync();


    public Task<Faculty> AddFacultyAsync(Faculty Faculty);

    public Task<Faculty> EditFacultyAsync(string id, Faculty faculty);
    public Task DeleteFacultytAsync(string id);
    public Task<List<Faculty>> GetFacultiesAsync();


    public Task<Teacher> AddTeacherAsync(Teacher teacher);
    public Task<Teacher> EditTeacherAsync(string id, Teacher teacher);
    public Task DeleteTeacherAsync(string id);
    public Task<List<Teacher>> GetTeachersAsync();


    public Task<Group> AddGroupAsync(Group group);
    public Task<Group> EditGroupAsync(string id, Group group);
    public Task DeleteGroupAsync(string id);
    public Task<List<Group>> GetGroupsAsync();
    public Task<Group> ChangeGroupTeacherAsync(string groupId, string teacherId);


    public Task<Student> AddStudentAsync(Student student);
    public Task<Student> EditStudentAsync(string id, Student student);
    public Task DeleteStudentAsync(string id);
    public Task<List<Student>> GetStudentsAsync();

}
