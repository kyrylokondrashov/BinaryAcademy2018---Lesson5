using DAL_EF.Models;
using System;
using System.Collections.Generic;

namespace Common.DTO
{
    public class FlightsDTO
    {
        public int Fid { get; set; }

        public string PointOfDepartures { get; set; }
        public DateTime TimeOfDeparture { get; set; }
        public string PointOfDestination { get; set; }
        public DateTime TimeOfArrival { get; set; }
        public List<TicketsDTO> Tickets { get; set; }

    }
}
