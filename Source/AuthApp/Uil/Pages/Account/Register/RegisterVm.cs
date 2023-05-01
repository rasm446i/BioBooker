using System.ComponentModel.DataAnnotations;

namespace BioBooker.AuthApp.Uil.Pages.Account.Register;

public class RegisterVm
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string ReturnUrl { get; set; }
    public string RoleName { get; set; }
}
