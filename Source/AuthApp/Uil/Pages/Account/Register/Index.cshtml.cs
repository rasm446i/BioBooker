using BioBooker.AuthApp.Uil.Data.Migrations;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BioBooker.AuthApp.Uil.Pages.Account.Register;

[SecurityHeaders]
[AllowAnonymous]
public class IndexModel : PageModel
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public IndexModel(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [BindProperty]
    public RegisterVm Input { get; set; }

    public async Task<IActionResult> OnGet(string returnUrl)
    {

        Input = new RegisterVm
        {
            ReturnUrl = returnUrl
        };
        return Page();
    }

    public async Task<IActionResult> OnPost(string returnUrl)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser()
            {
                UserName = Input.Email,
                Email = Input.Email,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                var userRole = new IdentityRole
                {
                    Name = "Standard",
                    NormalizedName = "STANDARD"
                };
                await _roleManager.CreateAsync(userRole);
                await _userManager.AddToRoleAsync(user, Input.RoleName);

                await _userManager.AddClaimsAsync(user, new Claim[] {
                new Claim(JwtClaimTypes.Email, Input.Email)
            });

            var login = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, true);

                if (login.Succeeded)
                {
                    if (Url.IsLocalUrl(Input.ReturnUrl))
                    {
                        return Redirect(Input.ReturnUrl);
                    }
                    else if (string.IsNullOrEmpty(Input.ReturnUrl))
                    {
                        return Redirect("/");
                    }
                    else
                    {
                        throw new Exception("Invalid Return URL!");
                    }
                }
            }
        }
        return Page();
    }
}
