using System.Text.RegularExpressions;

namespace AcademyAPI.Data.Models;

public class Student
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Name { get; set; }

    public string Surname { get; set; }

    public int Age { get; set; }


    public string? GroupId { get; set; }
    public Group Group { get; set; }

}
