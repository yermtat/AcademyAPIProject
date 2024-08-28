namespace AcademyAPI.Data.Models;

public class Teacher
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Subject { get; set; }
    public string? DepartmentId { get; set; }
    public Department Department { get; set; }
    public int WorkHours { get; set; }

    public ICollection<Group> Groups { get; set; }



}
