using CarRental.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using CarRental.Data;
using Microsoft.AspNetCore.Mvc;
using CarRental.ViewModels;

namespace CarRental.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICar _carRepsitory;
        private readonly ApplicationDbContext _context;
        public CarController(IHttpContextAccessor httpContextAccessor, ICar carRepsitory, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _carRepsitory = carRepsitory;
            _context = context;
        }


        // GET: CarController
        public ActionResult Index(int id)
        {
            return View();
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
        public async Task<ActionResult> Create(CarCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var car = new Car
            {

            };
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
