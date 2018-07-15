using System;
using DAL_EF.Models;
using System.Linq;
using DAL_EF.Interfaces;
using System.Collections.Generic;
using DAL_EF.Context;

namespace DAL_EF.Repositories
{
    public class AircraftsRepository: IRepository<Aircrafts>
    {
        AirportContext dataSource;
        public AircraftsRepository(AirportContext dataSource)
        {
            this.dataSource = dataSource;
        }

        public void Create(Aircrafts item)
        {
            dataSource.AircraftsList.Add(item);
            dataSource.SaveChanges();
        }

        public void Delete(int id)
        {
            var aircraft = dataSource.AircraftsList.Where(a => a.Id == id).FirstOrDefault();
            dataSource.AircraftsList.Remove(aircraft);
            dataSource.SaveChanges();
        }

        public void DeleteAll()
        {
          foreach(var e in dataSource.AircraftsList)
            {
                Delete(e.Id);
            }
        }

        public List<Aircrafts> GetAll()
        {
            return dataSource.AircraftsList.ToList();
        }

        public Aircrafts GetById(int id)
        {
            return dataSource.AircraftsList.Where(a => a.Id == id).FirstOrDefault();
        }

        public void Update(int id, Aircrafts item)
        {
            var aircraft = dataSource.AircraftsList.Where(acr => acr.Id == id).FirstOrDefault();
            dataSource.AircraftsList.Remove(aircraft);
            dataSource.AircraftsList.Add(item);
            dataSource.SaveChanges();

        }
    }
}
