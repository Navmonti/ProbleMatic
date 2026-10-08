namespace ProbleMatic.Domain.Entities;

public class Employee
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string JobTitle { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }

    private Employee()
    {
    }

    public Employee(string firstName, string lastName, string email, string jobTitle)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        JobTitle = jobTitle;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateProfile(string firstName, string lastName, string email, string jobTitle)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        JobTitle = jobTitle;
    }
}
