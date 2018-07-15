using System;
using DAL_EF.Interfaces;
using System.Collections.Generic;
using DAL_EF.Repositories;
using DAL_EF.Models;
using DAL_EF.Context;
using DAL_EF_EF.Repositories;

namespace DAL_EF.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        AirportContext context;
        private IRepository<Aircrafts> aircraftsRepository;
        private IRepository<AircraftsModels> aircraftsModelsRepository;
        private IRepository<Crews> crewsRepository;
        private IRepository<Departures> departuresRepository;
        private IRepository<Flights> flightsRepository;
        private IRepository<Pilots> pilotsRepository;
        private IRepository<Stewardesses> stewardessesRepository;
        private IRepository<Tickets> ticketsRepository;




        public IRepository<Aircrafts> AircraftsRepository
        {get
            {
                if (aircraftsRepository == null)
                {
                    aircraftsRepository = new AircraftsRepository(context);
                }
                return aircraftsRepository;
            }
        }

        public IRepository<AircraftsModels> AircraftsModelsRepository 
        {
            get
            {
                if (aircraftsModelsRepository == null)
                {
                    aircraftsModelsRepository = new AircraftsModelsRepository(context);
                }
                return aircraftsModelsRepository;
            }
        }

        public IRepository<Crews> CrewsRepository
        {
            get
            {
                if (crewsRepository == null)
                {
                    crewsRepository = new CrewsRepository(context);
                }
                return crewsRepository;
            }
        }

        public IRepository<Departures> DeparturesRepository 
        {
            get
            {
                if (departuresRepository == null)
                {
                    departuresRepository = new DeparturesRepository(context);
                }
                return departuresRepository;
            }
        }

        public IRepository<Flights> FlightsRepository 
        {
            get
            {
                if (flightsRepository == null)
                {
                    flightsRepository = new FlightsRepository(context);
                }
                return flightsRepository;
            }
        }

        public IRepository<Pilots> PilotsRepository 
        {
            get
            {
                if (pilotsRepository == null)
                {
                    pilotsRepository = new PilotsRepository(context);
                }
                return pilotsRepository;
            }
        }

        public IRepository<Stewardesses> StewardessesRepository 
        {
            get
            {
                if (stewardessesRepository == null)
                {
                    stewardessesRepository = new StewardessesRepository(context);
                }
                return stewardessesRepository;
            }
        }

        public IRepository<Tickets> TicketsRepository
        {
            get
            {
                if (ticketsRepository == null)
                {
                    ticketsRepository = new TicketsRepository(context);
                }
                return ticketsRepository;
            }
        }

        public UnitOfWork(AirportContext context)
        {
            this.context = context;
        }



        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
