namespace Auth.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string CompleteName { get; private set; }
    public string Email { get; private set; }
    public string? Company { get; private set; }
    public string? Country { get; private set; }
    public Guid PasswordSalt { get; private set; }
    public string PasswordHash { get; private set; }

    public User() { }

    public User(string completeName, string email, string? company, string? country, string passwordHash)
    {
        Id = Guid.NewGuid();
        PasswordSalt = Guid.NewGuid();
        CompleteName = completeName;
        Email = email;
        Company = company;
        Country = country;
        PasswordHash = passwordHash;
    }
}