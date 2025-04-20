using CarRental.Data;
using CarRental.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.ViewComponents
{
    public class CarViewComponent : ViewComponent
    {
        private readonly ICar _carRepository;

        public CarViewComponent(ICar carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int carId)
        {
            
        }
    }
}
