using System;
using DAL_EF.Models;
using System.Linq;
using DAL_EF.Interfaces;
using System.Collections.Generic;
using DAL_EF.Context;

namespace DAL_EF.Repositories
{
    public class AircraftsModelsRepository: IRepository<AircraftsModels>
    {
        AirportContext dataSource;
        public AircraftsModelsRepository(AirportContext dataSource)
        {
            this.dataSource = dataSource;
        }

        public void Create(AircraftsModels item)
        {
            dataSource.AircraftsModelsList.Add(item);
            dataSource.SaveChanges();
        }

        public void Delete(int id)
        {
            var am = dataSource.AircraftsModelsList.Where(aml => aml.Id == id).FirstOrDefault();
            dataSource.AircraftsModelsList.Remove(am);
            dataSource.SaveChanges();
        }

        public void DeleteAll()
        {
           foreach(var e in dataSource.AircraftsModelsList)
            {
                Delete(e.Id);
            }
        }

        public List<AircraftsModels> GetAll()
        {
            return dataSource.AircraftsModelsList.ToList();
        }

        public AircraftsModels GetById(int id)
        {
            var am = dataSource.AircraftsModelsList.Where(aml => aml.Id == id).FirstOrDefault();
            return am;
        }


        public void Update(int id, AircraftsModels item)
        {
            var t = dataSource.AircraftsModelsList.Where(aml => aml.Id == id).FirstOrDefault();
            dataSource.AircraftsModelsList.Remove(t);
            dataSource.AircraftsModelsList.Add(item);
            dataSource.SaveChanges();
        }
    }
}
