using Auth.Application.Request;
using Auth.Domain.Entities;

namespace Auth.Application.Interface.Map;

public interface IRoleMap
{
    public Role RoleRequestToRole(RoleRequest roleRequest);
}