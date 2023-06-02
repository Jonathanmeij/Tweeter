using System.ComponentModel.DataAnnotations;

namespace Tweeter.Shared.Models;

public class Post
{
    public String Id { get; set; }
    [Required, MaxLength(280)]
    public string Content { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string UserId { get; set; } 
    public User User { get; set; } 
    // public List<Like> Likes { get; set; } = new();
    // public List<Comment> Comments { get; set; } = new();
}