using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TravelAgency.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signinManager;
        [BindProperty]
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        
        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public LoginModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signinManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //var isValidUser =
            //       EmailAddress == "admin@admin.com"
            //    && Password == "adminadmin!";

            //if(!isValidUser) {
            //    ModelState.AddModelError("", "Invalid username or password!");
            //}

            if(!ModelState.IsValid)
            {
                return Page();
            }
            var result = await _signinManager.PasswordSignInAsync(
                EmailAddress, Password, false, false);
            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Login Error!");
                return Page();
            }
            return RedirectToPage("/Index");
            
            

            //var scheme = CookieAuthenticationDefaults.AuthenticationScheme;

            //var user = new ClaimsPrincipal(
            //    new ClaimsIdentity(
            //            new [] { new Claim(ClaimTypes.Name, EmailAddress) },
            //            scheme
            //        )
            //    );
            //HttpContext.SignInAsync(user);

            //return RedirectToPage("/Index");

        }
        public IActionResult OnPostRegister()
        {
            return RedirectToPage("/Account/Register");
        }
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await _signinManager.SignOutAsync();
            return RedirectToPage("/Index");
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //return RedirectToPage("/Index");
        }
    }
}