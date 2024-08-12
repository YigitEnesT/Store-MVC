using System.Security.Claims;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using StoreApp.Models;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Cart _cart;

        public OrderController(IServiceManager manager, Cart cart, UserManager<IdentityUser> userManager)
        {
            _manager = manager;
            _cart = cart;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult CheckOut()
        {
            var locations = LoadLocations();
            var cities = locations.Select(l => l.il).Distinct().ToList();

            ViewBag.Cities = new SelectList(cities);
            ViewBag.AllLocations = locations;

            return View(new Order());
        }

        private List<AddressViewModel> LoadLocations()
        {
            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Data", "il-ilce.json");
            var jsonData = System.IO.File.ReadAllText(jsonPath);

            return JsonConvert.DeserializeObject<List<AddressViewModel>>(jsonData);
        }

        [HttpGet]
        public IActionResult GetCounties(string city)
        {
            var locations = LoadLocations();
            var counties = locations
                .Where(l => l.il == city)
                .Select(l => l.ilce)
                .Distinct()
                .ToList();
            return Json(counties);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([FromForm] Order order)
        {
            if (_cart.Lines.Count() == 0)
                ModelState.AddModelError("", "Sorry, your cart is empty.");

            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                order.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                _manager.OrderService.SaveOrder(order);
                _cart.Clear();
                return RedirectToPage("/Complete", new { OrderId = order.OrderId });
            }
            var locations = LoadLocations();
            ViewBag.Cities = new SelectList(locations.Select(l => l.il).Distinct().ToList());
            ViewBag.AllLocations = locations;
            return View(order);
        }
    }
}