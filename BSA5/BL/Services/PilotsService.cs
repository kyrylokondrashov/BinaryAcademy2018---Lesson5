using System;
using System.Collections.Generic;
using BL.Interfaces;
using AutoMapper;
using DAL_EF.Interfaces;
using DAL_EF.Models;
using Common.DTO;
namespace BL.Services
{
    public class PilotsService: IService<PilotsDTO>
    {
        IUnitOfWork unitOfWork;

        public PilotsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(PilotsDTO item)
        {
            var pilots = unitOfWork.PilotsRepository.GetById(Convert.ToInt32(item.Pid));
            if (pilots == null)
            {

                var newPilot = Mapper.Map<PilotsDTO, Pilots>(item);
                unitOfWork.PilotsRepository.Create(newPilot);
            }
            else
            {
                throw new Exception($"Pilot with this id {item.Pid} has already been created");
            }
        }

        public void Delete(int id)
        {
            var pilot = unitOfWork.PilotsRepository.GetById(id);
            if (pilot != null)
            {
                unitOfWork.PilotsRepository.Delete(id);
            }
            else
            {
                throw new Exception($"Pilot with this id {id} has not been created");
            }
        }

        public void DeleteAll()
        {
            unitOfWork.PilotsRepository.DeleteAll();
        }


        public List<PilotsDTO> GetAll()
        {
            var all = unitOfWork.PilotsRepository.GetAll();
          
            return Mapper.Map<List<Pilots>, List<PilotsDTO>>(all);
        }

        public PilotsDTO GetById(int id)
        {
            var pilots = unitOfWork.PilotsRepository.GetById(id);
            if (pilots != null)
            {
               
                return Mapper.Map<Pilots, PilotsDTO>(pilots);
            }
            else
            {
                throw new Exception($"Pilots with this id {id} has not been created");
            }
        }

        public void Update(int id, PilotsDTO item)
        {
            var pilots = unitOfWork.PilotsRepository.GetById(id);
            if (pilots != null)
            {
               
                var newTicket = Mapper.Map<PilotsDTO, Pilots>(item);
                unitOfWork.PilotsRepository.Update(id, newTicket);
            }
            else
            {
                throw new Exception($"Pilot with this id {id} has not been created");
            }
        }
    }
}
