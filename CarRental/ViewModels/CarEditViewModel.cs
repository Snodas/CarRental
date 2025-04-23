using System.ComponentModel.DataAnnotations;

namespace CarRental.ViewModels
{
    public class CarEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Range(1886, 9999, ErrorMessage = "Please enter a valid year")]
        public int MakeYear { get; set; }

        [Required(ErrorMessage = "Image URL is required")]
        public string ImageUrl { get; set; }
    }
}
