namespace SharedTrip.Services
{
    using SharedTrip.Models;
    using SharedTrip.ViewModels.Trips;
    using System.Collections.Generic;

    public interface ITripsService
    {
        string Add(TripAddInputModel tripAddInputModel);

        IEnumerable<Trip> GetAll();

        DetailsViewModel GetDetails(string tripId);

        bool AddUserToTrip(string userId, string tripId);
    }
}
