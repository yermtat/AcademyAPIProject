namespace AcademyAPI.Data.Models;

public class Group
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public int Year { get; set; }

    public string? TeacherId { get; set; }
    public Teacher? Teacher { get; set; }

    public string? FacultyId { get; set; }
    public Faculty? Faculty { get; set; }

    public ICollection<Student> Students { get; set; }
}
