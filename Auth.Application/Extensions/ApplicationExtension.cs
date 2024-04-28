using Auth.Application.Comands.Create;
using Auth.Application.Comands.Update;
using Auth.Application.Interface.Comands.Create;
using Auth.Application.Interface.Map;
using Auth.Application.Map;
using Auth.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Application.Extensions;

public static class ApplicationExtension
{
    public static void AddAplication(this IServiceCollection service)
    {
        service.AddDbContext<AppDbContext>();
        service.AddTransient<IUserMap, UserMap>();
        service.AddTransient<IRoleMap, RoleMap>();
        service.AddTransient<UpdateUser>();
        service.AddScoped<ICreateUserRole, CreateUserRole>();
    }
}