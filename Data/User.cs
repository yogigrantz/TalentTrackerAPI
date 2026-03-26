using System;

namespace Data;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; } = "";
    public string Password { get; set; } = "";  
    public string? Email { get; set; }
    public string? Role { get; set; }
    public bool Active { get; set; }
    public DateTime DateAdded { get; } = DateTime.Now;
}
