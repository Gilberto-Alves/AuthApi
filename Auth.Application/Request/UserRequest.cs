using Auth.Domain.Enums;

namespace Auth.Application.Request;

public class UserRequest
{
    public string CompleteName { get; set; }
    public string Email { get; set; }
    public string? Company { get; set; }
    public string? Country { get; set; }
    public string PasswordHash { get; set; }
    public Category Category { get; set; }
}