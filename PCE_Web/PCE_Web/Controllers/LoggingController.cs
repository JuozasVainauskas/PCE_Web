﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PCE_Web.Classes;
using PCE_Web.Classes.ValidationAttributes;

namespace PCE_Web.Controllers
{
    public class LoggingController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        /*

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(InputModel input)
        {
            if (ModelState.IsValid)
            {
                var user = DatabaseManager.LoginUser(input.Email, input.Password);
                if (user != null)
                {
                    return View("~/Views/MainWindowLoggedIn/Items.cshtml");
                }
                else
                {
                    ViewBag.ShowMessage = true;
                }
            }

            return View("~/Views/Logging/Login.cshtml");
        }
        */
    }
}
