using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Linq;
using TalentTrack.DTO;

namespace TalentTrack.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegistrationController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok(UserService.Users.Select(u => new
        {
            u.UserId,
            u.UserName,
            u.Email,
            u.Role,
            u.Active,
            Password = u.Password // keep for demo, remove later
        }));
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult Register(RegisterRequestDTO request)
    {
        // Basic validation
        if (string.IsNullOrWhiteSpace(request.UserName) ||
            string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest("Username and password are required");
        }

        // Check if user already exists
        var existingUser = UserService.Users.FirstOrDefault(u => u.UserName.Equals(request.UserName, StringComparison.OrdinalIgnoreCase));

        if (existingUser != null)
            return BadRequest("Username already exists");

        if (request.Password.Length < 6)
            return BadRequest("Password too short. Must be at least 6 characters");

        // 🔥 Hash the password
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        // Generate next ID (simple POC style)
        int nextId = UserService.Users.Any()
            ? UserService.Users.Max(u => u.UserId) + 1
            : 1;

        var newUser = new User
        {
            UserId = nextId,
            UserName = request.UserName,
            Password = hashedPassword,
            Email = request.Email,
            Role = "RegularUser", // default role
            Active = true
        };

        UserService.Users.Add(newUser);

        return Ok(new
        {
            message = "User registered successfully",
            userId = newUser.UserId
        });
    }
}
