using System;
using DAL_EF.Models;
using System.Linq;
using DAL_EF.Interfaces;
using System.Collections.Generic;
using DAL_EF.Context;

namespace DAL_EF_EF.Repositories
{
    public class StewardessesRepository: IRepository<Stewardesses>
    {
        AirportContext dataSource;
        public StewardessesRepository(AirportContext dataSource)
        {
            this.dataSource = dataSource;
        }

        public void Create(Stewardesses item)
        {
            dataSource.StewardessesList.Add(item);
            dataSource.SaveChanges();
        }

        public void Delete(int id)
        {
            var stdw = dataSource.StewardessesList.Where(s => s.Id == id).FirstOrDefault();
            dataSource.StewardessesList.Remove(stdw);
            dataSource.SaveChanges();
        }

        public void DeleteAll()
        {
          foreach(var e in dataSource.StewardessesList)
            {
                Delete(e.Id);
            }
        }

        public List<Stewardesses> GetAll()
        {
            return dataSource.StewardessesList.ToList();
        }

        public Stewardesses GetById(int id)
        {
            return dataSource.StewardessesList.Where(s => s.Id == id).FirstOrDefault();
        }

        public void Update(int id, Stewardesses item)
        {
            var stdw = dataSource.StewardessesList.Where(s => s.Id == id).FirstOrDefault();
            dataSource.StewardessesList.Remove(stdw);
            dataSource.StewardessesList.Add(item);
            dataSource.SaveChanges();
        }
    }
}
