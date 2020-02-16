namespace SharedTrip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Trip
    {
        //•	Has an Id – a string, Primary Key
        //•	Has a StartPoint – a string (required)
        //•	Has a EndPoint – a string (required)
        //•	Has a DepartureTime – a datetime(required) (use format: "dd.MM.yyyy HH:mm")
        //•	Has a Seats – an integer with min value 2 and max value 6 (required)
        //•	Has a Description – a string with max length 80 (required)
        //•	Has a ImagePath – a string
        //•	Has UserTrips collection – a UserTrip type

        [Key]
        public string Id { get; set; }

        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{dd.MM.yyyy HH:mm}")]
        public DateTime DepartureTime { get; set; }

        [Required]
        public int Seats { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public virtual ICollection<UserTrips> userTrips { get; set; }
    }
}
