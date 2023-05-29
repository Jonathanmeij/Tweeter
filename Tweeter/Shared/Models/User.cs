using Microsoft.AspNetCore.Identity;

namespace Tweeter.Shared.Models;

public class User : IdentityUser
{
    public Uri? ProfilePicture { get; set; }
}