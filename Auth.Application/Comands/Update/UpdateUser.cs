using Auth.Application.Interface.Map;
using Auth.Application.Request;
using Auth.Application.Response;
using Auth.Domain.Entities;
using Auth.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Auth.Application.Comands.Update;

public class UpdateUser
{
    private readonly AppDbContext _appDbContext;

    public UpdateUser(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task UpdateCompleteUser(UserRequest userRequest, Guid id)
    {
        var user = await GetUserByeId(id);

        if (userRequest.CompleteName != string.Empty)
            user.CompleteName = userRequest.CompleteName.ToUpper();
        if (userRequest.Country != string.Empty)
            user.Country = userRequest.Country;
        if (userRequest.Company != string.Empty)
            user.Company = userRequest.Company;

        await _appDbContext.SaveChangesAsync();
    }

    
    
    private async Task<User> GetUserByeId(Guid id)
    {
        var user = await _appDbContext.Users.SingleOrDefaultAsync(p => p.Id == id);
        
        return user;
    }
}