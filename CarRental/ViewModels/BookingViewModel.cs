﻿namespace CarRental.ViewModels
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public string CarBrandModel { get; set; }
        public string UserFullName { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
