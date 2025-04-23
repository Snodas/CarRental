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
                Console.WriteLine((string)storedUser.PassWord);
            }

            var cars = await _carRepository.GetAllCarsAsync();
            return View(cars);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Car()
        {
            if (!_authService.IsUserLoggedIn())
            {
                TempData["Error"] = "You must be logged in to view this page.";
                return RedirectToAction("Login", "Account");
            }
            
            return View();
        }

        public IActionResult Bookings()
        {
            if (!_authService.IsUserLoggedIn())
            {
                TempData["Error"] = "You must be logged in to view this page.";
                return RedirectToAction("Login", "Account");
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
