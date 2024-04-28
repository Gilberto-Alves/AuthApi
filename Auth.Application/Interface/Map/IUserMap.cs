using Auth.Application.Request;
using Auth.Application.Response;
using Auth.Domain.Entities;

namespace Auth.Application.Interface.Map;

public interface IUserMap
{
    public Task<(ErrorMessageResponse? errorMessageResponse, User? user, bool success)> UserRequestToUser(UserRequest userRequest);
}