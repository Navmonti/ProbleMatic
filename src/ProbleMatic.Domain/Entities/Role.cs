namespace ProbleMatic.Domain.Entities;

public class Role
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();
    public DateTime CreatedAt { get; private set; }

    private Role()
    {
    }

    public Role(string name)
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
