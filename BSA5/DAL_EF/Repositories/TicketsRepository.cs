using System;
using DAL_EF.Models;
using System.Linq;
using DAL_EF.Interfaces;
using System.Collections.Generic;
using DAL_EF.Context;

namespace DAL_EF.Repositories
{
    public class TicketsRepository: IRepository<Tickets>
    {
        AirportContext dataSource;
        public TicketsRepository(AirportContext dataSource)
        {
            this.dataSource = dataSource;
        }

        public void Create(Tickets item)
        {
            dataSource.TicketsList.Add(item);
            dataSource.SaveChanges();
        }

        public void Delete(int id)
        {
            var ticket = dataSource.TicketsList.Where(t => t.Id == id).FirstOrDefault();
            dataSource.TicketsList.Remove(ticket);
            dataSource.SaveChanges();
        }

        public void DeleteAll()
        {
          foreach(var e in dataSource.TicketsList)
            {
                Delete(e.Id);
            }
        }

        public List<Tickets> GetAll()
        {
            return dataSource.TicketsList.ToList();
        }

        public Tickets GetById(int id)
        {
            return dataSource.TicketsList.Where(t => t.Id == id).FirstOrDefault();
        }

        public void Update(int id, Tickets item)
        {
            var t = dataSource.TicketsList.Where(tt => tt.Id == id).FirstOrDefault();
            dataSource.TicketsList.Remove(t);
            dataSource.TicketsList.Add(item);
            dataSource.SaveChanges();
        }
    }
}
