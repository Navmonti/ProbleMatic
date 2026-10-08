namespace ProbleMatic.Domain.Entities;

public class Ticket
{
    public Guid Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Status { get; private set; } = "Open";
    public Guid CreatorUserId { get; private set; }
    public Guid DepartmentId { get; private set; }
    public Guid? AssignedEmployeeId { get; private set; }

    public User CreatorUser { get; private set; } = null!;
    public Department Department { get; private set; } = null!;
    public Employee? AssignedEmployee { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private Ticket()
    {
    }

    public Ticket(
        string title,
        string description,
        Guid creatorUserId,
        Guid departmentId,
        Guid? assignedEmployeeId,
        string? status = null)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Status = status ?? "Open";
        CreatorUserId = creatorUserId;
        DepartmentId = departmentId;
        AssignedEmployeeId = assignedEmployeeId;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(
        string title,
        string description,
        string status,
        Guid creatorUserId,
        Guid departmentId,
        Guid? assignedEmployeeId)
    {
        Title = title;
        Description = description;
        Status = status;
        CreatorUserId = creatorUserId;
        DepartmentId = departmentId;
        AssignedEmployeeId = assignedEmployeeId;
    }

    public void AssignToEmployee(Guid employeeId)
    {
        AssignedEmployeeId = employeeId;
    }

    public void UnassignEmployee()
    {
        AssignedEmployeeId = null;
    }
}
