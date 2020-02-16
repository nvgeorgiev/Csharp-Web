namespace SharedTrip.Services
{
    using SharedTrip.Models;
    using SharedTrip.ViewModels.Trips;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string Add(TripAddInputModel tripAddInputModel)
        {
            var trip = new Trip()
            {
                Id = Guid.NewGuid().ToString(),
                StartPoint = tripAddInputModel.StartPoint,
                EndPoint = tripAddInputModel.EndPoint,
                DepartureTime = tripAddInputModel.DepartureTime,
                Seats = tripAddInputModel.Seats,
                Description = tripAddInputModel.Description,
                ImagePath = tripAddInputModel.ImagePath
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();

            return trip.Id;
        }

        public IEnumerable<Trip> GetAll()
            => this.db.Trips
            .Select(x => new Trip
            {
                Id = x.Id,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime,
                ImagePath = x.ImagePath,
                Seats = x.Seats,
                Description = x.Description
            })
            .ToArray();

        public DetailsViewModel GetDetails(string tripId)
        {
            var trip = this.db.Trips
                .Where(x => x.Id == tripId)
                .Select(x => new DetailsViewModel
                {
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime,
                    Seats = x.Seats,
                    Description = x.Description
                })
                .FirstOrDefault();

            return trip;
        }

        public bool AddUserToTrip(string userId, string tripId)
        {
            var userTrip = new UserTrips
            {
                UserId = userId,
                TripId = tripId
            };

            if (this.db.UserTrips.FirstOrDefault(x => x.UserId == userId && x.TripId == tripId) != null)
            {
                return false;
            }

            var trip = this.db.Trips.FirstOrDefault(x => x.Id == tripId);

            trip.Seats--;
            if (trip.Seats < 0)
            {
                return false;
            }

            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();

            return true;
        }
    }
}
