using DAL_EF.Models;
using System;
using System.Collections.Generic;

namespace Common.DTO
{
    public class FlightsDTO
    {
        public int Id { get; set; }

        public string PointOfDepartures { get; set; }
        public DateTime TimeOfDeparture { get; set; }
        public string PointOfDestination { get; set; }
        public DateTime TimeOfArrival { get; set; }
        public List<Tickets> Tickets { get; set; }

    }
}
