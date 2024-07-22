using RideHubb.Domain.Abstractions;
using RideHubb.Domain.Users.Events;

namespace RideHubb.Domain.Users;

public sealed class User : Entity
{
    private User(
        Guid id,
        string email,
        string passwordHash,
        Role role,
        string firstName,
        string lastName,
        bool isEmailVerified,
        DateTime createdAt
        ) : base(id)
    {
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
        FirstName = firstName;
        LastName = lastName;
        IsEmailVerified = isEmailVerified;
        CreatedAt = createdAt;
    }
    
    // This empty constructor is necessary for Entity Framework,
    // they require a constructor without parameters for instance creation.
    private User() { }
    
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public Role Role { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public bool IsEmailVerified { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    public static User Register(
        string email,
        string passwordHash,
        Role role,
        string firstName,
        string lastName,
        DateTime createdAt
        )
    {
        var user = new User(
            Guid.NewGuid(),
            email,
            passwordHash,
            role,
            firstName,
            lastName,
            false,
            createdAt
        );
        
        user.AddDomainEvent(new UserRegisterDomainEvent(user.Id));
        
        return user;
    }
}