using Data;
using System.Collections.Generic;

namespace Services;

public class UserService
{
    public static List<User> Users = new List<User>()
    {
        new User()
        {
            UserId = 1,
            UserName = "Yogi",
            Password = BCrypt.Net.BCrypt.HashPassword("20002026!"),
            Email = "test@tester.com",
            Role = "Admin",
            Active = true
        },
        new User()
        {
            UserId = 2,
            UserName = "Butter",
            Password = BCrypt.Net.BCrypt.HashPassword("2014!"),
            Email = "test1@tester.com",
            Role = "RegularUser",
            Active = true
        },
        new User()
        {
            UserId = 3,
            UserName = "Cocoa",
            Password = BCrypt.Net.BCrypt.HashPassword("2014!"),
            Email = "test1@tester.com",
            Role = "RegularUser",
            Active = true
        },
        new User()
        {
            UserId = 4,
            UserName = "Pebble",
            Password = BCrypt.Net.BCrypt.HashPassword("2014!"),
            Email = "test1@tester.com",
            Role = "RegularUser",
            Active = false
        }
    };
}
