namespace Auth.Application.Response;

public class ErrorMessageResponse
{
    public List<string> Errors { get; set; } = new();
}