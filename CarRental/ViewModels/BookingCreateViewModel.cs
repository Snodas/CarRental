﻿namespace CarRental.ViewModels
{
    public class BookingCreateViewModel
    {
        public int CarId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
