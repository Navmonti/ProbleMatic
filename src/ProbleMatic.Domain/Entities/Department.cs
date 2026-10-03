namespace ProbleMatic.Domain.Entities;

public class Department
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }

    private Department()
    {
    }

    public Department(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
}
