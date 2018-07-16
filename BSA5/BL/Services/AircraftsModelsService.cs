using System;
using System.Collections.Generic;
using BL.Interfaces;
using AutoMapper;
using DAL_EF.Interfaces;
using DAL_EF.Models;
using Common.DTO;
namespace BL.Services
{
    public class AircraftsModelsService: IService<AircraftsModelsDTO>
    {
        IUnitOfWork unitOfWork;

        public AircraftsModelsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(AircraftsModelsDTO item)
        {
            var aircrafts = unitOfWork.AircraftsModelsRepository.GetById(item.AMid);
            if (aircrafts == null)
            {
                var newPilot = Mapper.Map<AircraftsModelsDTO, AircraftsModels>(item);
                unitOfWork.AircraftsModelsRepository.Create(newPilot);
            }
            else
            {
                throw new Exception($"AircraftsModels with this id {item.AMid} has already been created");
            }
        }

        public void Delete(int id)
        {
            var aircrafts = unitOfWork.AircraftsModelsRepository.GetById(id);
            if (aircrafts != null)
            {
                unitOfWork.AircraftsModelsRepository.Delete(id);
            }
            else
            {
                throw new Exception($"AircraftsModels with this id {id} has not been created");
            }
        }

        public void DeleteAll()
        {
            unitOfWork.AircraftsModelsRepository.DeleteAll();
        }


        public List<AircraftsModelsDTO> GetAll()
        {
            var all = unitOfWork.AircraftsModelsRepository.GetAll();
            return Mapper.Map<List<AircraftsModels>, List<AircraftsModelsDTO>>(all);
        }

        public AircraftsModelsDTO GetById(int id)
        {
            var aircrafts = unitOfWork.AircraftsModelsRepository.GetById(id);
            if (aircrafts != null)
            {
                return Mapper.Map<AircraftsModels, AircraftsModelsDTO>(aircrafts);
            }
            else
            {
                throw new Exception($"AircraftsModels with this id {id} has not been created");
            }
        }

        public void Update(int id, AircraftsModelsDTO item)
        {
            var aircrafts = unitOfWork.AircraftsModelsRepository.GetById(id);
            if (aircrafts != null)
            {
                var newTicket = Mapper.Map<AircraftsModelsDTO, AircraftsModels>(item);
                unitOfWork.AircraftsModelsRepository.Update(id, newTicket);
            }
            else
            {
                throw new Exception($"AircraftsModels with this id {id} has not been created");
            }
        }

    }
}
