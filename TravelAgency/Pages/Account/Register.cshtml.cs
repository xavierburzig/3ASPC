using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TravelAgency.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        [BindProperty]
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //var isValidUser =
            //       EmailAddress == "admin@admin.com"
            //    && Password == "adminadmin!";

            //if (!isValidUser)
            //{
            //    ModelState.AddModelError("", "Invalid username or password!");
            //}

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var newUser = new IdentityUser
            {
                Email = EmailAddress,
                UserName = EmailAddress,
            };

            var result = await _userManager.CreateAsync(newUser, Password);

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors.Select(x => x.Description))
                {
                    ModelState.AddModelError("", error);
                }
                return Page();
            }
            return RedirectToPage("/Index");

        }
    }
}
