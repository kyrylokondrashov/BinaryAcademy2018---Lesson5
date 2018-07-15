using System;
using System.Collections.Generic;
using BL.Interfaces;
using AutoMapper;
using DAL_EF.Interfaces;
using DAL_EF.Models;
using Common.DTO;
namespace BL.Services
{
    public class CrewsService:IService<CrewsDTO>
    {
        IUnitOfWork unitOfWork;

        public CrewsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(CrewsDTO item)
        {
            var crews = unitOfWork.CrewsRepository.GetById(item.Id);
            if (crews == null)
            {
                var newPilot = Mapper.Map<CrewsDTO, Crews>(item);
                unitOfWork.CrewsRepository.Create(newPilot);
            }
            else
            {
                throw new Exception($"Crews with this id {item.Id} has already been created");
            }
        }

        public void Delete(int id)
        {
            var crews = unitOfWork.CrewsRepository.GetById(id);
            if (crews != null)
            {
                unitOfWork.CrewsRepository.Delete(id);
            }
            else
            {
                throw new Exception($"Crews with this id {id} has not been created");
            }
        }

        public void DeleteAll()
        {
            unitOfWork.CrewsRepository.DeleteAll();
        }


        public List<CrewsDTO> GetAll()
        {
            var all = unitOfWork.CrewsRepository.GetAll();
            return Mapper.Map<List<Crews>, List<CrewsDTO>>(all);
        }

        public CrewsDTO GetById(int id)
        {
            var crews = unitOfWork.CrewsRepository.GetById(id);
            if (crews != null)
            {
                return Mapper.Map<Crews, CrewsDTO>(crews);
            }
            else
            {
                throw new Exception($"Crews with this id {id} has not been created");
            }
        }

        public void Update(int id, CrewsDTO item)
        {
            var crews = unitOfWork.CrewsRepository.GetById(id);
            if (crews != null)
            {
                var newTicket = Mapper.Map<CrewsDTO, Crews>(item);
                unitOfWork.CrewsRepository.Update(id, newTicket);
            }
            else
            {
                throw new Exception($"Crews with this id {id} has not been created");
            }
        }
    }

}

