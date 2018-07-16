using DAL_EF.Models;
using System;
namespace Common.DTO
{
    public class DeparturesDTO
    {
        public int Did { get; set; }

        public FlightsDTO Flight { get; set; }
        public DateTime DepartureDate { get; set; }
        public CrewsDTO Crew { get; set; }
        public AircraftsDTO Aircraft { get; set; }
    }
}
