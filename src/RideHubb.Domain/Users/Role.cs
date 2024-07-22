namespace RideHubb.Domain.Users;

public record Role
{
    private static readonly Role Admin = new("Admin");
    private static readonly Role Driver = new("Driver");
    private static readonly Role Passenger = new("Passenger");

    public string Value { get; }
    
    private Role(string value)
    {
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public static Role Create(string value)
    {
        return value switch
        {
            "Admin" => Admin,
            "Driver" => Driver,
            "Passenger" => Passenger,
            _ => throw new ArgumentException("Invalid role value")
        };
    }

    public static readonly IReadOnlyCollection<Role> All = new[]
    {
        Admin, 
        Driver, 
        Passenger
    };
}