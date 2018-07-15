using System;
using DAL_EF.Models;
using System.Linq;
using DAL_EF.Interfaces;
using System.Collections.Generic;
using DAL_EF.Context;

namespace DAL_EF.Repositories
{
    public class PilotsRepository: IRepository<Pilots>
    {
        AirportContext dataSource;
        public PilotsRepository(AirportContext dataSource)
        {
            this.dataSource = dataSource;
        }

        public void Create(Pilots item)
        {
            dataSource.PilotsList.Add(item);
            dataSource.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = dataSource.PilotsList.Where(p => p.Id == id).FirstOrDefault();
            dataSource.PilotsList.Remove(item);
            dataSource.SaveChanges();
        }

        public void DeleteAll()
        {
           foreach(var e in dataSource.PilotsList)
            {
                Delete(e.Id);
            }
        }

        public List<Pilots> GetAll()
        {
            return dataSource.PilotsList.ToList();
        }

        public Pilots GetById(int id)
        {
            return dataSource.PilotsList.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Update(int id, Pilots item)
        {
            var temp = dataSource.PilotsList.Where(p => p.Id == id).FirstOrDefault();
            dataSource.PilotsList.Remove(temp);
            dataSource.PilotsList.Add(item);
            dataSource.SaveChanges();
        }
    }
}
