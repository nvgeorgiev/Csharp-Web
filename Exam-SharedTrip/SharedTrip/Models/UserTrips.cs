namespace SharedTrip.Models
{
    public class UserTrips
    {
        //•	Has UserId – a string
        //•	Has User – a User object
        //•	Has TripId– a string
        //•	Has Trip – a Trip object

        public string UserId { get; set; }

        public User User { get; set; }

        public string TripId { get; set; }

        public Trip Trip { get; set; }
    }
}