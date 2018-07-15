using System;
using DAL_EF.Models;
using System.Linq;
using DAL_EF.Interfaces;
using System.Collections.Generic;
using DAL_EF.Context;

namespace DAL_EF.Repositories
{ 
    public class DeparturesRepository: IRepository<Departures>
    {
       AirportContext dataSource;
        public DeparturesRepository(AirportContext dataSource)
        {
            this.dataSource = dataSource;
        }

        public void Create(Departures item)
        {
            dataSource.DeparturesList.Add(item);
            dataSource.SaveChanges();
        }

        public void Delete(int id)
        {
            var departures = dataSource.DeparturesList.Where(d => d.Id == id).FirstOrDefault();
            dataSource.DeparturesList.Remove(departures);
            dataSource.SaveChanges();
        }

        public void DeleteAll()
        {
           foreach(var e in dataSource.DeparturesList)
            {
                Delete(e.Id);
            }
        }

        public List<Departures> GetAll()
        {
            return dataSource.DeparturesList.ToList();
        }

        public Departures GetById(int id)
        {
            return dataSource.DeparturesList.Where(d => d.Id == id).FirstOrDefault();
        }

        public void Update(int id, Departures item)
        {
            var crews = dataSource.DeparturesList.Where(acr => acr.Id == id).FirstOrDefault();
            dataSource.DeparturesList.Remove(crews);
            dataSource.DeparturesList.Add(item);
            dataSource.SaveChanges();
        }
    }
}
