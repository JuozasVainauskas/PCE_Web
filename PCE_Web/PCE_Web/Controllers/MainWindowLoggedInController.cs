﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCE_Web.Classes;
using PCE_Web.Models;

namespace PCE_Web.Controllers
{
    [Authorize]
    public class MainWindowLoggedInController : Controller
    {
        public static int IsDeletedOrSaved = 1;
        private readonly IDatabaseManager _databaseManager;

        public MainWindowLoggedInController(IDatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        public IActionResult Items(string link, string pictureUrl, string seller, string name, string price)
        {
            if (link != null)
            {
                var productToDelete = new Item
                {
                    Link = link,
                    Picture = pictureUrl,
                    Seller = seller,
                    Name = name,
                    Price = price
                };
                _databaseManager.DeleteSavedItem(User.Identity.Name, productToDelete);
                IsDeletedOrSaved = 0;
            }

            if (IsDeletedOrSaved == 1)
            {
                SlideshowView.AlertBoxText = "Sėkmingai prisijungėte!";
            }
            else if (IsDeletedOrSaved == 0)
            {
                SlideshowView.AlertBoxText = "Sėkmingai ištrinta prekė!";
            }
            else
            {
                SlideshowView.AlertBoxText = "Sveiki sugrįžę!";
            }

            if (_databaseManager.ReadSlidesList().Any())
            {
                var products = _databaseManager.ReadSlidesList();
                var productsSaved = _databaseManager.ReadSavedItems(User.Identity.Name);
               
                var slideshowView = new SlideshowView
                {
                    ProductsSaved = productsSaved,
                    Products = products
                };

                IsDeletedOrSaved = 2;
                return View(slideshowView);
            }
            else
            {
                var products = new List<Slide>();
                var productsSaved = _databaseManager.ReadSavedItems(User.Identity.Name);
                var notExistingItem = new Slide
                {
                    PageUrl = "",
                    ImgUrl = "~/img/suggestions/1.jpg"
                };
                products.Add(notExistingItem);

                var slideshowView = new SlideshowView
                {
                    Products = products,
                    ProductsSaved = productsSaved
                };
                IsDeletedOrSaved = 2;
                return View(slideshowView);
            }
  
        }

        public IActionResult Report(string report)
        {
            _databaseManager.WriteReports(User.Identity.Name,report);
            return RedirectToAction("Items", "MainWindowLoggedIn");
        }
    }
}
