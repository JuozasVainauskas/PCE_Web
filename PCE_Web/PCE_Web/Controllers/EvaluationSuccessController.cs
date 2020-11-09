﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCE_Web.Classes;

namespace PCE_Web.Controllers
{
    [Authorize]
    public class EvaluationSuccessController : Controller
    {

        public IActionResult Success(int shopId, int rate,string comment)
        {
            
            var currentEmail = MainWindowLoggedInController.EmailCurrentUser;

            if (!DatabaseManager.IsAlreadyCommented(currentEmail,shopId) && currentEmail!=null && shopId!= 0 && rate!=0)
            {
                DatabaseManager.WriteComments(currentEmail, shopId, rate, comment);
                return View();
            }
            else
            {
                return RedirectToAction("Failure", "EvaluationSuccess");
            }
            
        }

        public IActionResult Failure()
        {
            return View();
        }
    }
}
