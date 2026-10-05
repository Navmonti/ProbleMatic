namespace ProbleMatic.Domain.Entities;

public class Ticket
{
    public Guid Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Status { get; private set; } = "Open";
    public DateTime CreatedAt { get; private set; }

    private Ticket()
    {
    }

    public Ticket(string title, string description, string? status = null)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Status = status ?? "Open";
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(string title, string description, string status)
    {
        Title = title;
        Description = description;
        Status = status;
    }
}
