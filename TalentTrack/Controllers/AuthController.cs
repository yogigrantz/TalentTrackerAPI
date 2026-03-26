using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TalentTrack.DTO;

namespace TalentTrack.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IConfiguration config, ILogger<AuthController> logger)
    {
        _config = config;
        this._logger = logger;
    }

    [HttpGet("login")]
    [AllowAnonymous]
    public IActionResult DisplayOK()
    {
        _logger.LogInformation("Test 123...");
        return Ok("Ready...");
    }


    [HttpPost("login")]
    [AllowAnonymous]
    public IActionResult Login(LoginRequest request)
    {
        // For demo only — hardcoded validation
        var user = UserService.Users.FirstOrDefault(u => u.UserName.Equals(request.Username,StringComparison.OrdinalIgnoreCase) && u.Active);
        if (user == null)
            return Unauthorized("User does not exist");

        bool isValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

        if (!isValid)
            return Unauthorized("Invalid credentials");

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.UserName??""),
            new Claim(ClaimTypes.Role, user.Role ?? "")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]??""));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: creds
        );

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token)
        });
    }
}
