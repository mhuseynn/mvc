using Microsoft.AspNetCore.Identity;
using WebApplication4.Models.Abstracts;

namespace WebApplication4.Models.Concretes;

public class AppUser : IdentityUser
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
}
