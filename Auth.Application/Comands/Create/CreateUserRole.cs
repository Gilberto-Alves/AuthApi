using Auth.Application.Interface.Comands.Create;
using Auth.Application.Response;
using Auth.Domain.Entities;
using Auth.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Auth.Application.Comands.Create;

public class CreateUserRole : ICreateUserRole
{
    private readonly AppDbContext _appDbContext;

    public CreateUserRole(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<(ErrorMessageResponse? errorMessageResponse, bool success)> CreateAsync(object t)
    {
        var errors = new ErrorMessageResponse();
        
        object? joker = t switch
        {
            User user => await _appDbContext.Users.SingleOrDefaultAsync(p => p.Email == user.Email),
            Role role => await _appDbContext.Roles.SingleOrDefaultAsync(p =>p != null && p.Name == role.Name),
            _ => null
        };

        errors.Errors.Add("Existing registration!");
        if (joker is not null)
            return (errors, false);
        
        await _appDbContext.AddAsync(t);
        await _appDbContext.SaveChangesAsync();

        return (null, true);
    }
}