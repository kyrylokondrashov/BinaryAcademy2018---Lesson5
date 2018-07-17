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
            var departures = dataSource.DeparturesList.Where(d => d.Did == id).FirstOrDefault();
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
            var a = dataSource.DeparturesList.ToList();
            foreach(var t in a)
            {
                dataSource.Entry(t).Reference(x => x.Aircraft).Load();
                dataSource.Entry(t).Reference(x => x.Flight).Load();
                dataSource.Entry(t).Reference(x => x.Crew).Load();
            }
            return a;
        }

        public Departures GetById(int id)
        {
            var t = dataSource.DeparturesList.Where(d => d.Id == id).FirstOrDefault();
            dataSource.Entry(t).Reference(x => x.Aircraft).Load();
            dataSource.Entry(t).Reference(x => x.Flight).Load();
            dataSource.Entry(t).Reference(x => x.Crew).Load();
            return t;
        }

        public void Update(int id, Departures item)
        {
            var crews = dataSource.DeparturesList.Where(acr => acr.Id == id).FirstOrDefault();
            var am = dataSource.AircraftsList.Where(ams => ams.Aid == item.Aircraft.Aid).ToList().FirstOrDefault();
            var am1 = dataSource.FlightsList.Where(ams => ams.Fid == item.Flight.Fid).ToList().FirstOrDefault();
            var am2 = dataSource.CrewsList.Where(ams => ams.Cid == item.Crew.Cid).ToList().FirstOrDefault();
            crews.Flight = am1;
            crews.Crew = am2;
            crews.Aircraft = am;
            crews = item;
            dataSource.SaveChanges();
        }
    }
}
