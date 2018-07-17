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
            var t = dataSource.FlightsList.ToList();
            foreach(var t1 in t)
            {
                dataSource.Entry(t1).Collection(x => x.Tickets).Load();
            }
            return t;
        }

        public Flights GetById(int id)
        {
            var t = dataSource.FlightsList.Where(a => a.Fid == id).FirstOrDefault();
            if (t != null)
            {
                dataSource.Entry(t).Collection(x => x.Tickets).Load();
            }
            return t;
        }

        public void Update(int id, Flights item)
        {
            var a = dataSource.FlightsList.Where(f => f.Fid == id).FirstOrDefault();

            dataSource.Entry(a).Collection(x => x.Tickets).Load();
            a.Tickets = null;
            List<Tickets> newList = new List<Tickets>();
            foreach (var s in item.Tickets)
            {
                var t = dataSource.TicketsList.Where(ss => ss.Tid == s.Tid).ToList().FirstOrDefault();
                newList.Add(t);

            }
            a.Tickets = new List<Tickets>(newList);
            dataSource.SaveChanges();
        }
    }
}
