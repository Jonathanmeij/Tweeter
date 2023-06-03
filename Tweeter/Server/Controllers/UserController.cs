using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tweeter.Shared.Models;

namespace Tweeter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        
        public UserController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet("{username}")]
        public async Task<ActionResult<UserResponse>> GetUser(string username)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            var user = _context.Users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                return NotFound();
            }

            var userResponse = new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                ProfilePicture = user.ProfilePicture
            };

            return userResponse;
        }
        
        [HttpGet("{username}/posts")]
        public async Task<ActionResult<PostsResponse>> GetUserPosts(string username)
        {
            if (_context.Users == null)
            {
                return NotFound("No users found.");
            }

            var user = _context.Users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            var posts = _context.Posts.Where(p => p.UserId == user.Id).Include(p => p.User);
            
            if (!posts.Any())
            {
                return NotFound("No posts found.");
            }
            
            var postsResponse = new PostsResponse
            {
                Posts = posts.Select(p => new PostResponse
                {
                    Id = p.Id,
                    Content = p.Content,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    UserId = p.UserId,
                    Username = p.User.UserName,
                    ProfilePicture = p.User.ProfilePicture
                })
            };

            return postsResponse;
        }
    }
}
