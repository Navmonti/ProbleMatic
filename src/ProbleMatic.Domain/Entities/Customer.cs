namespace ProbleMatic.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;
    public User User { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }

    private Customer()
    {
    }

    public Customer(string firstName, string lastName, string email, string phoneNumber, Guid userId = default)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateProfile(string firstName, string lastName, string email, string phoneNumber, Guid userId)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}
