using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_EF.Models
{
    public class Departures
    {
        [System.ComponentModel.DataAnnotations.Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Did { get; set; }
        public Flights Flight { get; set; }
        public DateTime DepartureDate { get; set; }
        public Crews Crew { get; set; }
        public Aircrafts Aircraft { get; set; }
    }
}
