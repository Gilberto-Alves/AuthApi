using Auth.Application.Interface.Map;
using Auth.Application.Request;
using Auth.Application.Response;
using Auth.Domain.Entities;
using Auth.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Auth.Application.Map;

public class UserMap : IUserMap
{
    private readonly AppDbContext _appDbContext;

    public UserMap(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<(ErrorMessageResponse? errorMessageResponse, User? user, bool success)> UserRequestToUser(UserRequest userRequest)
    {
        var error = new ErrorMessageResponse();
        var role = await _appDbContext.Roles.SingleOrDefaultAsync(p => p != null && p.Name == userRequest.Category.ToString());

        if (role is null)
        {
            error.Errors.Add("Role nonexistent");
            return (error, null, false);
        }

        var passwordSalt = Guid.NewGuid();
        
        var userPassword = userRequest.PasswordHash + passwordSalt;
        
        var user = new User
        {
            Id = Guid.NewGuid(),
            CompleteName = userRequest.CompleteName.ToUpper(),
            Email = userRequest.Email.ToLower(),
            PasswordSalt = passwordSalt,
            Company = userRequest.Company,
            Country = userRequest.Country,
            Roles = { role },
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(userPassword)
        };

        return (null, user, true);
    }
}