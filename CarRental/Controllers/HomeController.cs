using CarRental.Data;
using System.Diagnostics;
using CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using CarRental.Data.Interfaces;
using CarRental.Services.Auth;

namespace CarRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthService _authService;
        private readonly ICar _carRepository;
        private readonly IBooking _bookingRepository;

        public HomeController(
            ILogger<HomeController> logger,
            IAuthService authService,
            ICar carRepository,
            IBooking bookingRepository)
        {
            _logger = logger;
            _authService = authService;
            _carRepository = carRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<IActionResult> Index()
        {
            var storedUser = HttpContext.Session.GetObject<dynamic>("User");
            if (storedUser != null)
            {
                Console.WriteLine(storedUser.PassWord);
            }

            //var cars = await _carRepository.GetAllAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Bookings()
        {
            if (!_authService.IsUserLoggedIn())
            {
                TempData["ErrorMessage"] = "Du måste vara inloggad för att se dina bokningar.";
                return RedirectToAction("Account", "Login");
            }
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
