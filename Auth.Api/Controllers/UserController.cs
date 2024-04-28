using Auth.Application.Comands.Update;
using Auth.Application.Interface.Comands.Create;
using Auth.Application.Interface.Map;
using Auth.Application.Request;
using Auth.Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    [HttpPost("Create-User")]
    public async Task<IActionResult> AddUser([FromBody]UserRequest userRequest, 
        [FromServices] IUserMap map, 
        [FromServices] ICreateUserRole createUserRole)
    {
        var errorResult = new ErrorMessageResponse();
        
        var user = await map.UserRequestToUser(userRequest);
        
        
        if(user.success is false)
            errorResult.Errors.AddRange(user.errorMessageResponse.Errors);

        if (user is { success: true, user: not null })
        {
            var (UserCreateError, success) = await createUserRole.CreateAsync(user.user);
            
            if (success)
                return Ok("User Registered!");

            errorResult.Errors.AddRange(UserCreateError.Errors);
        }

        return BadRequest(errorResult);
    }

    [HttpPost("Update-name{id:guid}")]
    public async Task<IResult> UpdateUser([FromRoute] Guid id, [FromBody]UserRequest userRequest, [FromServices] UpdateUser user)
    {
        await user.UpdateCompleteUser(userRequest, id);

        return Results.Ok("Updated");
    }
}