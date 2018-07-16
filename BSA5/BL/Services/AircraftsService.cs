using System;
using System.Collections.Generic;
using BL.Interfaces;
using AutoMapper;
using DAL_EF.Interfaces;
using DAL_EF.Models;
using Common.DTO;
namespace BL.Services
{
    public class AircraftsService: IService<AircraftsDTO>
    {
        IUnitOfWork unitOfWork;

        public AircraftsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(AircraftsDTO item)
        {
            var aircrafts = unitOfWork.AircraftsRepository.GetById(item.Aid);
            if (aircrafts == null)
            {
                var newPilot = Mapper.Map<AircraftsDTO, Aircrafts>(item);
                unitOfWork.AircraftsRepository.Create(newPilot);
            }
            else
            {
                throw new Exception($"Aircrafts with this id {item.Aid} has already been created");
            }
        }

        public void Delete(int id)
        {
            var aircrafts = unitOfWork.AircraftsRepository.GetById(id);
            if (aircrafts == null)
            {
                unitOfWork.AircraftsRepository.Delete(id);
            }
            else
            {
                throw new Exception($"Aircrafts with this id {id} has not been created");
            }
        }

        public void DeleteAll()
        {
            unitOfWork.AircraftsRepository.DeleteAll();
        }


        public List<AircraftsDTO> GetAll()
        {
            var all = unitOfWork.AircraftsRepository.GetAll();
            return Mapper.Map<List<Aircrafts>, List<AircraftsDTO>>(all);
        }

        public AircraftsDTO GetById(int id)
        {
            var aircrafts = unitOfWork.AircraftsRepository.GetById(id);
            if (aircrafts != null)
            {
                return Mapper.Map<Aircrafts, AircraftsDTO>(aircrafts);
            }
            else
            {
                throw new Exception($"Aircrafts with this id {id} has not been created");
            }
        }

        public void Update(int id, AircraftsDTO item)
        {
            var aircrafts = unitOfWork.AircraftsRepository.GetById(id);
            if (aircrafts != null)
            {
                var newTicket = Mapper.Map<AircraftsDTO, Aircrafts>(item);
                unitOfWork.AircraftsRepository.Update(id, newTicket);
            }
            else
            {
                throw new Exception($"Aircrafts with this id {id} has not been created");
            }
        }
    }
}
