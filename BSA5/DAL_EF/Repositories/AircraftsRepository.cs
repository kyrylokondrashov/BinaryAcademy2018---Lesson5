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
            var aircraft = dataSource.AircraftsList.Where(a => a.Aid == id).FirstOrDefault();
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
           var all = dataSource.AircraftsList.ToList();
            foreach(var t in all)
            {
                dataSource.Entry(t).Reference(x => x.AircraftsModels).Load();
            }
            return all;
        }

        public Aircrafts GetById(int id)
        {
            var t =  dataSource.AircraftsList.Where(a => a.Aid == id).FirstOrDefault();
            dataSource.Entry(t).Reference(x => x.AircraftsModels).Load();
            return t;
        }

        public void Update(int id, Aircrafts item)
        {
            var a = dataSource.AircraftsList.Where(acr => acr.Aid == id).FirstOrDefault();
            var am = dataSource.AircraftsModelsList.Where(ams => ams.AMid == item.AircraftsModels.AMid).ToList().FirstOrDefault();
            a.AircraftsModels = am;
            a = item;
            dataSource.SaveChanges();
        }
    }
}
