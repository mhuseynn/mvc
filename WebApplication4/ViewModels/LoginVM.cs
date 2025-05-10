using System.ComponentModel.DataAnnotations;

namespace WebApplication4.ViewModels;

public class LoginVM
{
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }

    public bool  IsPersistent { get; set; }
}
