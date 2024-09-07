namespace AcademyAPI.Data.Models.Academy;

public class Faculty
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public int DepartmentsNumber { get; set; }

    public ICollection<Group> Groups { get; set; }
}
