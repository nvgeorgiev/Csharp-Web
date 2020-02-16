namespace SharedTrip.ViewModels.Trips
{
    using System;

    public class TripAddInputModel
    {
        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; } // Server might not be able to map DateTime. If error occurs change it to string.

        public string ImagePath { get; set; }

        public int Seats { get; set; }

        public string Description { get; set; }
    }
}
