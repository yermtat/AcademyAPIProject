﻿namespace AcademyAPI.Data.Models.Academy;

public class Department
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }

    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
