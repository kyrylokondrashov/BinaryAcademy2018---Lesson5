using System;
using System.Collections.Generic;
using DAL_EF.Models;
namespace DAL_EF.Interfaces
{
    public interface ISource
    {
        List<Aircrafts> AircraftsList { get; set; }
        List<AircraftsModels> AircraftsModelsList { get; set; }
        List<Crews> CrewsList { get; set; }
        List<Departures> DeparturesList { get; set; }
        List<Flights> FlightsList { get; set; }
        List<Pilots> PilotsList { get; set; }
        List<Stewardesses> StewardessesList { get; set; }
        List<Tickets> TicketsList { get; set; }
    }
}
