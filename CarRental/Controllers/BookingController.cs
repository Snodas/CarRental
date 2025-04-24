using CarRental.Data;
using CarRental.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRental.ViewModels;
using CarRental.Services.Auth;
using CarRental.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRental.Services;

namespace CarRental.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthService _authService;
        private readonly ApplicationDbContext _context;
        private readonly ICar _carRepository;
        private readonly IBaseUser _baseUserRepository;
        private readonly IBooking _bookingRepository;
        private readonly IBookingService _bookingService;

        public BookingController(IHttpContextAccessor httpContextAccessor, IAuthService authService, ApplicationDbContext context, ICar carRepository, IBaseUser baseUserRepository, IBooking bookingRepository, IBookingService bookingService)
        {
            _httpContextAccessor = httpContextAccessor;
            _authService = authService;
            _context = context;
            _carRepository = carRepository;
            _baseUserRepository = baseUserRepository;
            _bookingRepository = bookingRepository;
            _bookingService = bookingService;
        }


        // GET: BookingController
        public async Task<ActionResult> Index()
        {
            if (!_authService.IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            var bookings = await _context.Bookings
                .Include(b => b.Car)
                .Include(b => b.User)
                .ToListAsync();

            //var bookings = await _bookingRepository.GetAllBookingsAsync();
            var bookingViewModels = bookings.Select(booking => new BookingViewModel
            {
                Id = booking.Id,
                CarBrandModel = booking.Car != null ? $"{booking.Car.Brand} {booking.Car.Model}" : "Unknown Car",
                UserFullName = booking.User != null ? $"{booking.User.FirstName} {booking.User.LastName}" : "Unknown User",
                StartDate = booking.StartDate,
                EndDate = booking.EndDate
            });

            return View(bookingViewModels);
        }

        public async Task<ActionResult> MyBookingsIndex()
        {
            if (!_authService.IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            var userId = _authService.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var bookings = await _context.Bookings
                .Include(b => b.Car)
                .Include(b => b.User)
                .Where(b => b.UserId == userId)
                .ToListAsync();

            var bookingViewModels = bookings.Select(booking => new BookingViewModel
            {
                Id = booking.Id,
                CarBrandModel = booking.Car != null ? $"{booking.Car.Brand} {booking.Car.Model}" : "Unknown Car",
                UserFullName = booking.User != null ? $"{booking.User.FirstName} {booking.User.LastName}" : "Unknown User",
                StartDate = booking.StartDate,
                EndDate = booking.EndDate
            });

            return View(bookingViewModels);
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookingController/Create
        public ActionResult Create(int carId)
        {
            var userId = _authService.GetUserId();

            ViewBag.Cars = _context.Cars
            .Select(car => new SelectListItem
            {
                Value = car.Id.ToString(),
                Text = $"{car.Brand} {car.Model}",
                Selected = car.Id == carId  
            })
            .ToList();

            ViewBag.Users = _context.BaseUsers
                .Select(user => new SelectListItem
                {
                    Value = user.Id.ToString(),
                    Text = $"{user.FirstName} {user.LastName}",
                    Selected = user.Id == userId
                })
                .ToList();

            return View();
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BookingCreateViewModel x)
        {
            if (ModelState.IsValid)
            {
                var isValid = await _bookingService.ValidateBooking(x.CarId, x.StartDate, x.EndDate);
                if (!isValid)
                {
                    ModelState.AddModelError("", "The selected car is already booked during the selected dates or the end date is before the start date.");
                    return View(x);
                }

                var booking = new Booking
                {
                    CarId = x.CarId,
                    UserId = x.UserId,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate
                };
                await _bookingRepository.AddAsync(booking);
                
                if (await _authService.IsUserAdmin())
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(MyBookingsIndex));
                }
            }

            ViewBag.Cars = _context.Cars
                .Select(car => new SelectListItem
                {
                    Value = car.Id.ToString(),
                    Text = $"{car.Brand} {car.Model}"
                })
                .ToList();

            ViewBag.Users = _context.BaseUsers
                .Select(user => new SelectListItem
                {
                    Value = user.Id.ToString(),
                    Text = $"{user.FirstName} {user.LastName}"
                })
                .ToList();

            return View(x);
        }

        // GET: BookingController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var booking = await _bookingRepository.GetAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            var bookingEditViewModel = new BookingEditViewModel
            {
                Id = booking.Id,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate
            };

            return View(bookingEditViewModel);
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, BookingEditViewModel x)
        {
            if (id != x.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var booking = await _bookingRepository.GetAsync(id);
                if (booking == null)
                {
                    return NotFound();
                }

                booking.StartDate = x.StartDate;
                booking.EndDate = x.EndDate;

                await _bookingRepository.UpdateAsync(booking);

                if (await _authService.IsUserAdmin())
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(MyBookingsIndex));
                }
            }            
            return View(x);
        }

        // GET: BookingController/Delete/5
        public ActionResult Delete(int id)
        {
            var booking = _bookingRepository.GetAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var booking = await _bookingRepository.GetAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            
            await _bookingRepository.RemoveAsync(booking);
            return RedirectToAction(nameof(Index));
        }
    }
}
