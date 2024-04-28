using Auth.Application.Response;

namespace Auth.Application.Interface.Comands.Create;

public interface ICreateUserRole
{
    public Task<(ErrorMessageResponse? errorMessageResponse, bool success)> CreateAsync(object t);
}