using DAL_EF.Models;
using DAL_EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL_EF.Data
{
    public class DBInitializer
    {

        public static void Initialize(AirportContext airportDbContext)
        {

            airportDbContext.Database.EnsureCreated();

            var stewardesses = new List<Stewardesses>
       {
                new Stewardesses{ Sid = 1, Name= "Alica", Surname="Alison", DateOfBirth = new DateTime(1990,09,12,12,13,14)},
                new Stewardesses{ Sid = 2, Name= "Rosa", Surname="Rosason", DateOfBirth = new DateTime(1990,09,13,12,13,14)},
                new Stewardesses{  Sid = 3,Name= "Eva", Surname="Evason", DateOfBirth = new DateTime(1990,09,12,14,13,14)},
                new Stewardesses{  Sid = 4,Name= "Jenn", Surname="Jennson", DateOfBirth = new DateTime(1990,09,15,12,13,14)},
                new Stewardesses{ Sid=5, Name= "Hermy", Surname="Hermyson", DateOfBirth = new DateTime(1990,09,16,12,13,14)},
                new Stewardesses{ Sid = 6, Name= "Alica", Surname="Evason", DateOfBirth = new DateTime(1990,09,12,17,13,14)}
       };


            if (!airportDbContext.StewardessesList.Any())
            {
                foreach (var s in stewardesses)
                {
                    airportDbContext.StewardessesList.Add(s);
                }
            }



            var pilots = new Pilots[]
            {
                new Pilots{ Pid =1 ,Name="Henry", Surname="Henryson",DateOfBirth = new DateTime(1980,09,12,12,13,14), Experience = 10},
                new Pilots{ Pid=2 ,Name="Andrew", Surname="Andrewson",DateOfBirth = new DateTime(1980,09,13,12,13,14), Experience = 11},
                new Pilots{ Pid =3 ,Name="Jonh", Surname="Jonhson",DateOfBirth = new DateTime(1980,09,12,14,13,14), Experience = 12},
                new Pilots{ Pid= 4, Name="Harry", Surname="Harryson",DateOfBirth = new DateTime(1980,09,15,12,13,14), Experience = 13}
            };

            if (!airportDbContext.PilotsList.Any())
            {
                foreach (var s in pilots)
                {
                    airportDbContext.PilotsList.Add(s);
                }
            }

            var crews = new Crews[]
            {
                new Crews {Cid =1 ,Pilot = pilots[0],StewardessList = new List<Stewardesses>{stewardesses[0],stewardesses[1]}},
                new Crews {Cid =2 ,Pilot = pilots[1],StewardessList = new List<Stewardesses>{stewardesses[2]}},
                new Crews {Cid = 3,Pilot = pilots[2],StewardessList = new List<Stewardesses>{stewardesses[3], stewardesses[4]}},
                new Crews {Cid = 4, Pilot = pilots[3],StewardessList = new List<Stewardesses>{stewardesses[5]}},
            };

            if (!airportDbContext.CrewsList.Any())
            {
                foreach (var s in crews)
                {
                    airportDbContext.CrewsList.Add(s);
                }
            }


            var aircraftsModels = new List<AircraftsModels>
            {
                new AircraftsModels{ ModelName="Antonov-111", AircraftTonnage=1000, PlacesCount=500},
                new AircraftsModels{ ModelName="Ruslanov-222", AircraftTonnage=1200, PlacesCount=600},
                new AircraftsModels{ ModelName="Karasov-333", AircraftTonnage=1400, PlacesCount=700},
                new AircraftsModels{ ModelName="Menesov-444", AircraftTonnage=1600, PlacesCount=800}
            };

            if (!airportDbContext.AircraftsModelsList.Any())
            {
                foreach (var s in aircraftsModels)
                {
                    airportDbContext.AircraftsModelsList.Add(s);
                }
            }


            var aircrafts = new List<Aircrafts>
            {
                new Aircrafts{AircraftName="Tyt101", AircraftBuildDate=new DateTime(2000,10,12,15,18,10), AircraftsModels = aircraftsModels[0], AircraftExpluatationSpan= new TimeSpan(500,0,0).Ticks},
                new Aircrafts{ AircraftName="Ty202", AircraftBuildDate=new DateTime(2001,10,12,15,18,10), AircraftsModels = aircraftsModels[1], AircraftExpluatationSpan= new TimeSpan(600,0,0).Ticks},
                new Aircrafts{ AircraftName="Ty303", AircraftBuildDate=new DateTime(1999,10,12,15,18,10), AircraftsModels = aircraftsModels[2], AircraftExpluatationSpan= new TimeSpan(700,0,0).Ticks},
                new Aircrafts{ AircraftName="Ty404", AircraftBuildDate=new DateTime(1998,10,12,15,18,10), AircraftsModels = aircraftsModels[3], AircraftExpluatationSpan= new TimeSpan(800,0,0).Ticks}
            };

            if (!airportDbContext.AircraftsList.Any())
            {
                foreach (var s in aircrafts)
                {
                    airportDbContext.AircraftsList.Add(s);
                }
            }

            var tickets = new Tickets[]{
                new Tickets{ Price= 100, Flight= null},
                new Tickets{ Price= 100, Flight= null},
                new Tickets{ Price= 101, Flight= null},
                new Tickets{ Price= 101, Flight= null},
                new Tickets{ Price= 102, Flight= null},
                new Tickets{ Price= 102, Flight= null},
                new Tickets{Price= 103, Flight= null},
                new Tickets{ Price= 103, Flight= null}
            };


            if (!airportDbContext.TicketsList.Any())
            {
                foreach (var t in tickets)
                {
                    airportDbContext.TicketsList.Add(t);
                }

            }


            var flights = new List<Flights> {
                new Flights {PointOfDepartures="kiev/zhulyany",  TimeOfDeparture =new DateTime(2018,10,12,15,18,10), PointOfDestination = "london/hitrow",TimeOfArrival=new DateTime(2018,10,13,15,18,10),Tickets=new List<Tickets>{ tickets[0], tickets[1]} },
                new Flights {PointOfDepartures="kiev/zhulyany", TimeOfDeparture = new DateTime(2018,10,13,16,19,10), PointOfDestination  ="tokio/haneda", TimeOfArrival = new DateTime(2018,10,14,15,18,10),Tickets=new List<Tickets>{ tickets[2], tickets[3]}},
                new Flights {PointOfDepartures="kiev/zhulyany", TimeOfDeparture = new DateTime(2018,10,14,17,20,10), PointOfDestination  ="hong-kong/hka", TimeOfArrival = new DateTime(2018,10,15,15,18,10),Tickets=new List<Tickets>{ tickets[4], tickets[5] }},
                new Flights {PointOfDepartures="kiev/zhulyany", TimeOfDeparture = new DateTime(2018,10,15,18,21,10), PointOfDestination = "new-york/nwa", TimeOfArrival = new DateTime(2018,10,16,15,18,10),Tickets=new List<Tickets>{tickets[6], tickets[7]}}
                };


            if (!airportDbContext.FlightsList.Any())
            {
                foreach (var f in flights)
                {
                    airportDbContext.FlightsList.Add(f);
                }
            }



            var departures = new List<Departures> {

                new Departures{ Flight =flights[0], DepartureDate=new DateTime(2018,10,12,15,18,10), Crew = crews[0], Aircraft=aircrafts[0] },
                new Departures{ Flight =flights[1], DepartureDate=new DateTime(2018,10,13,15,18,10), Crew = crews[1], Aircraft=aircrafts[0] },
                new Departures{ Flight =flights[2], DepartureDate=new DateTime(2018,10,14,15,18,10), Crew = crews[2], Aircraft=aircrafts[0] },
                new Departures{ Flight =flights[3], DepartureDate=new DateTime(2018,10,15,15,18,10), Crew = crews[3], Aircraft=aircrafts[0] }
                };


            if (!airportDbContext.DeparturesList.Any())
            {
                foreach (var f in departures)
                {
                    airportDbContext.DeparturesList.Add(f);
                }
            }

            airportDbContext.SaveChanges();

        }
    }
 
}
