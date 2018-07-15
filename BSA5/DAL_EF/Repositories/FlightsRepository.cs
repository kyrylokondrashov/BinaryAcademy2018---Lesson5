using System;
using DAL_EF.Models;
using DAL_EF.Context;
using System.Linq;
using DAL_EF.Interfaces;
using System.Collections.Generic;

namespace DAL_EF.Repositories
{
    public class FlightsRepository: IRepository<Flights>
    {
        AirportContext dataSource;
        public FlightsRepository(AirportContext dataSource)
        {
            this.dataSource = dataSource;
        }

        public void Create(Flights item)
        {
            dataSource.FlightsList.Add(item);
            dataSource.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = dataSource.FlightsList.Where(f => f.Id == id).FirstOrDefault();
            dataSource.FlightsList.Remove(item);
            dataSource.SaveChanges();
        }

        public void DeleteAll()
        {
           foreach(var e in dataSource.FlightsList)
            {
                Delete(e.Id);
            }
        }

        public List<Flights> GetAll()
        {
            return dataSource.FlightsList.ToList();
        }

        public Flights GetById(int id)
        {
            var item = dataSource.FlightsList.Where(f => f.Id == id).FirstOrDefault();
            return item;
        }

        public void Update(int id, Flights item)
        {
            var temp = dataSource.FlightsList.Where(f => f.Id == id).FirstOrDefault();
            dataSource.FlightsList.Remove(temp);
            dataSource.FlightsList.Add(item);
            dataSource.SaveChanges();
        }
    }
}
