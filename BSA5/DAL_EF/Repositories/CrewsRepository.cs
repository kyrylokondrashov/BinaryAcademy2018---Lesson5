using System;
using System.Linq;
using DAL_EF.Models;
using DAL_EF.Context;
using DAL_EF.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
            var crews = dataSource.CrewsList.Where(c => c.Cid == id).FirstOrDefault();
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
            var a = dataSource.CrewsList.ToList();
            foreach(Crews s in a)
            {
                dataSource.Entry(s).Reference(x => x.Pilot).Load();
                dataSource.Entry(s).Collection(x => x.StewardessList).Load();
            }
            return a;
        }

        public Crews GetById(int id)
        {
            var a = dataSource.CrewsList.Where(c => c.Cid == id).SingleOrDefault();
            if (a != null)
            {
                dataSource.Entry(a).Reference(x => x.Pilot).Load();
                dataSource.Entry(a).Collection(x => x.StewardessList).Load();
            }
            return a;
        }

        public void Update(int id, Crews item)
        {
            try
            {
                var a = dataSource.CrewsList.Where(c => c.Cid == id).FirstOrDefault();
                dataSource.Entry(a).Reference(x => x.Pilot).Load();
                dataSource.Entry(a).Collection(x => x.StewardessList).Load();

                var p = dataSource.PilotsList.Where(x => x.Pid == item.Pilot.Pid).ToList().FirstOrDefault();
                a.Cid = item.Cid;
                a.Pilot = p;

                a.StewardessList = null;
                List<Stewardesses> newList = new List<Stewardesses>();
                foreach(var s in item.StewardessList)
                {
                    var t = dataSource.StewardessesList.Where(ss=>ss.Sid == s.Sid).ToList().FirstOrDefault();
                    newList.Add(t);
                   
                }
                a.StewardessList = new List<Stewardesses>(newList);
                dataSource.SaveChanges();
            }
            catch
            {

            }
        
        }
    }
}
