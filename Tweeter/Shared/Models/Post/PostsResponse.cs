namespace Tweeter.Shared.Models;

public class PostsResponse
{
    public IEnumerable<PostResponse> Posts { get; set; } = new List<PostResponse>();
}

public class PostResponse : Post
{
    public Uri ProfilePicture { get; set; } = null!;
    public string Username { get; set; } = null!;
}