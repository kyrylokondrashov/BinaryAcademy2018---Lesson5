using System;
using System.Collections.Generic;
using BL.Interfaces;
using AutoMapper;
using DAL_EF.Interfaces;
using DAL_EF.Models;
using Common.DTO;
namespace BL.Services
{
    public class FlightsService: IService<FlightsDTO>
    {
        IUnitOfWork unitOfWork;

        public FlightsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(FlightsDTO item)
        {
            var flights = unitOfWork.FlightsRepository.GetById(item.Fid);
            if (flights == null)
            {
                var newPilot = Mapper.Map<FlightsDTO, Flights>(item);
                unitOfWork.FlightsRepository.Create(newPilot);
            }
            else
            {
                throw new Exception($"Flights with this id {item.Fid} has already been created");
            }
        }

        public void Delete(int id)
        {
            var flights = unitOfWork.FlightsRepository.GetById(id);
            if (flights != null)
            {
                unitOfWork.FlightsRepository.Delete(id);
            }
            else
            {
                throw new Exception($"Flights with this id {id} has not been created");
            }
        }

        public void DeleteAll()
        {
            unitOfWork.FlightsRepository.DeleteAll();
        }


        public List<FlightsDTO> GetAll()
        {
            var all = unitOfWork.FlightsRepository.GetAll();
            return Mapper.Map<List<Flights>, List<FlightsDTO>>(all);
        }

        public FlightsDTO GetById(int id)
        {
            var flights = unitOfWork.FlightsRepository.GetById(id);
            if (flights != null)
            {
                return Mapper.Map<Flights, FlightsDTO>(flights);
            }
            else
            {
                throw new Exception($"Flights with this id {id} has not been created");
            }
        }

        public void Update(int id, FlightsDTO item)
        {
            var flights = unitOfWork.FlightsRepository.GetById(id);
            if (flights != null)
            {
                var newTicket = Mapper.Map<FlightsDTO, Flights>(item);
                unitOfWork.FlightsRepository.Update(id, newTicket);
            }
            else
            {
                throw new Exception($"Flights with this id {id} has not been created");
            }
        }
    }

}
