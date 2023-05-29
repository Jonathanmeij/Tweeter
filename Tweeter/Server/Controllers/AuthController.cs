using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Tweeter.Server.Models;
using Tweeter.Server.Services;
using Tweeter.Shared.Models;

namespace Tweeter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly DataContext _contex;
        
        public AuthController(UserManager<User> userManager, TokenService tokenService, IConfiguration configuration, DataContext context)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _configuration = configuration;
            _contex = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result = await _userManager.CreateAsync(
                new User
                {
                    UserName = request.Username,
                    Email = request.Email,
                    ProfilePicture = request.ProfilePicture
                }, request.Password);

            var userInDb = await _userManager.FindByEmailAsync(request.Email);

            if (userInDb == null)
            {
                return Unauthorized("Invalid credentials");
            }  

            if (result.Succeeded)
            {
                request.Password = "";

                var accessToken = _tokenService.CreateToken(userInDb, _configuration);
                await _contex.SaveChangesAsync();
                
                return Ok(new LoginResponse
                {
                    Username = userInDb.UserName,
                    Email = userInDb.Email,
                    Token = accessToken
                });   
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var managedUser = await _userManager.FindByEmailAsync(request.Email);
            
            if (managedUser == null)
            {
                return BadRequest("Invalid credentials");
            }
            
            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);
            
            if (!isPasswordValid)
            {
                return BadRequest("Invalid credentials");
            }
            
            var userInDb = await _userManager.FindByEmailAsync(request.Email);
            
            if (userInDb == null)
            {
                return Unauthorized();
            }

            var accessToken = _tokenService.CreateToken(userInDb, _configuration);
            await _contex.SaveChangesAsync();
            
            return Ok(new LoginResponse
            {
                Username = userInDb.UserName,
                Email = userInDb.Email,
                Token = accessToken
            });
        }

    }
}


