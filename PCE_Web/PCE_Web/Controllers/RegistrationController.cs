﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PCE_Web.Classes;
using PCE_Web.Classes.ValidationAttributes;

namespace PCE_Web.Controllers
{
    public class RegistrationController : Controller
    {
        public class InputModel
        {
            [Display(Name = "Email")]
            [DataType(DataType.EmailAddress)]
            [Required(ErrorMessage = "Turite įrašyti email.")]
            [EmailSpelling]
            [EmailExistence]
            public string Email { get; set; }

            [Display(Name = "Password")]
            [DataType(DataType.Password)]
            [Required(ErrorMessage = "Turite įrašyti slaptažodį.")]
            [StringLength(100, MinimumLength = 4, ErrorMessage = "Slaptažodis turi būti bet 4 simbolių ilgio.")]
            [PasswordSpelling]
            public string Password { get; set; }

            [Display(Name = "Confirm password")]
            [DataType(DataType.Password)]
            [Required(ErrorMessage = "Turite patvirtinti slaptažodį.")]
            [Compare("Password", ErrorMessage = "Slaptažodis turi sutapti su patvirtinimo slaptažodžiu.")]
            public string ConfirmPassword { get; set; }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(InputModel input)
        {
            if (ModelState.IsValid)
            {
                DatabaseManager.RegisterUser(input.Email, input.Password);
                MainWindowLoggedInController.EmailCurrentUser = input.Email;
                MainWindowLoggedInController.isDeletedOrSaved = 1;
                return RedirectToAction("Items", "MainWindowLoggedIn");
            }

            return View();
        }
    }
}
