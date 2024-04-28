namespace Auth.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string CompleteName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Company { get; set; }
    public string? Country { get; set; }
    public Guid PasswordSalt { get; set; }
    public string PasswordHash { get; set; } = string.Empty;

    public List<Role> Roles { get; private set; } = new();
    
}