namespace Tweeter.Shared.Models;

public class UserResponse
{
    public string UserName { get; set; } = null!;
    public Uri? ProfilePicture { get; set; }
    public string Id { get; set; } = null!;
}