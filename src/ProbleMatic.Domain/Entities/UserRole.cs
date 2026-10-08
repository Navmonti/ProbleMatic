namespace ProbleMatic.Domain.Entities;

public class UserRole
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid RoleId { get; private set; }
    public User User { get; private set; } = null!;
    public Role Role { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }

    private UserRole()
    {
    }

    public UserRole(Guid userId, Guid roleId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        RoleId = roleId;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateAssignment(Guid userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
}
