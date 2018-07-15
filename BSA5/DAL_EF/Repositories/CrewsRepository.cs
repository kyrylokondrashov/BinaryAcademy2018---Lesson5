using System;
using System.Linq;
using DAL_EF.Models;
using DAL_EF.Context;
using DAL_EF.Interfaces;
using System.Collections.Generic;

namespace DAL_EF.Repositories
{
    public class CrewsRepository: IRepository<Crews>
    {
        AirportContext dataSource;

        public CrewsRepository(AirportContext dataSource)
        {
            this.dataSource = dataSource;
        }

        public void Create(Crews item)
        {
            dataSource.CrewsList.Add(item);
            dataSource.SaveChanges();
        }

        public void Delete(int id)
        {
            var crews = dataSource.CrewsList.Where(c => c.Id == id).FirstOrDefault();
            dataSource.CrewsList.Remove(crews);
            dataSource.SaveChanges();
        }

        public void DeleteAll()
        {
           foreach(var e in dataSource.CrewsList)
            {
                Delete(e.Id);
            }
        }


        public List<Crews> GetAll()
        {
            return dataSource.CrewsList.ToList();
        }

        public Crews GetById(int id)
        {
            return dataSource.CrewsList.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Update(int id, Crews item)
        {
            var crews = dataSource.CrewsList.Where(acr => acr.Id == id).FirstOrDefault();
            dataSource.CrewsList.Remove(crews);
            dataSource.CrewsList.Add(item);
            dataSource.SaveChanges();

        }
    }
}
