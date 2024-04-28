using Auth.Application.Interface.Map;
using Auth.Application.Request;
using Auth.Domain.Entities;

namespace Auth.Application.Map;

public class RoleMap : IRoleMap
{
    public Role RoleRequestToRole(RoleRequest roleRequest)
    {
        var role = new Role(roleRequest.Name);

        return role;
    }
}