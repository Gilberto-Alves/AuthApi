using Auth.Application.Interface.Comands.Create;
using Auth.Application.Interface.Map;
using Auth.Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RoleController : ControllerBase
{
    [HttpPost("Create-Role")]
    public async Task<IActionResult> AddRole([FromBody] RoleRequest roleRequest,
        [FromServices] IRoleMap roleMap,
        [FromServices] ICreateUserRole createUserRole)
    {
        var role = roleMap.RoleRequestToRole(roleRequest);

        var roleResult = await createUserRole.CreateAsync(role);

        if (roleResult.success)
            return Ok("Role Created");

        return BadRequest(roleResult.errorMessageResponse);
    }
}