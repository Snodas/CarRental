using CarRental.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using CarRental.Data;
using Microsoft.AspNetCore.Mvc;
using CarRental.ViewModels;
using CarRental.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CarRental.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICar _carRepsitory;
        private readonly IBooking _bookingRepository;
        private readonly ApplicationDbContext _context;
        
        public CarController(IHttpContextAccessor httpContextAccessor, ICar carRepsitory, IBooking bookingRepository, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _carRepsitory = carRepsitory;
            _bookingRepository = bookingRepository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _carRepsitory.GetAllCarsAsync();
            var carViewModels = cars.Select(car => new CarViewModel
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                MakeYear = car.MakeYear,
                ImageUrl = car.ImageUrl
            });
            return View(carViewModels);
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CarCreateViewModel x)
        {
            if (ModelState.IsValid)
            {
                var car = new Car
                {
                    Brand = x.Brand,
                    Model = x.Model,
                    MakeYear = x.MakeYear,
                    ImageUrl = x.ImageUrl
                };

                await _carRepsitory.AddAsync(car);                            
                return RedirectToAction(nameof(Index));
            }

            return View(x);
        }


        // GET: CarController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var car = await _carRepsitory.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            var carEditViewModel = new CarEditViewModel
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                MakeYear = car.MakeYear,
                ImageUrl = car.ImageUrl
            };

            return View(carEditViewModel);
        }


        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarEditViewModel x)
        {
            if (id != x.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var car = await _carRepsitory.GetAsync(id);
                if (car == null)
                {
                    return NotFound();
                }

                car.Brand = x.Brand;
                car.Model = x.Model;
                car.MakeYear = x.MakeYear;
                car.ImageUrl = x.ImageUrl;

                await _carRepsitory.UpdateAsync(car);
                return RedirectToAction(nameof(Index));
            }

            return View(x);
        }

        // GET: CarController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var car = await _carRepsitory.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var car = await _carRepsitory.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            await _carRepsitory.RemoveAsync(car);
            return RedirectToAction(nameof(Index));
        }
    }
}
