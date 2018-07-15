using System;
using System.Collections.Generic;
using BL.Interfaces;
using AutoMapper;
using DAL_EF.Interfaces;
using DAL_EF.Models;
using Common.DTO;
namespace BL.Services
{
    public class TicketsServices: IService<TicketsDTO>
    {
        IUnitOfWork unitOfWork;
            
        public TicketsServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(TicketsDTO item) // add validator
        {
            var ticket = unitOfWork.TicketsRepository.GetById(item.Id);
            if(ticket == null)
            {
                var newTicket = Mapper.Map<TicketsDTO, Tickets>(item);
                unitOfWork.TicketsRepository.Create(newTicket);
            }
            else
            {
                throw new Exception($"Ticket with this id {item.Id} has already been created");  
            }
        }

        public void Delete(int id)
        {
            var ticket = unitOfWork.TicketsRepository.GetById(id);
            if (ticket != null)
            {
                unitOfWork.TicketsRepository.Delete(id);
            }
            else
            {
                throw new Exception($"Ticket with this id {id} has not been created");
            }
        }

        public void DeleteAll()
        {
            unitOfWork.TicketsRepository.DeleteAll();
        }

        public List<TicketsDTO> GetAll()
        {
            var all = unitOfWork.TicketsRepository.GetAll();
            return Mapper.Map<List<Tickets>, List<TicketsDTO>>(all);
        }

        public TicketsDTO GetById(int id)
        {
            var ticket = unitOfWork.TicketsRepository.GetById(id);
            if (ticket != null)
            {
                return Mapper.Map<Tickets, TicketsDTO>(ticket);
            }
            else
            {
                throw new Exception($"Ticket with this id {id} has not been created");
            }
        }

        public void Update(int id, TicketsDTO item) //add validator
        {
            var ticket = unitOfWork.TicketsRepository.GetById(id);
            if (ticket != null)
            {
                var newTicket = Mapper.Map<TicketsDTO, Tickets>(item);
                unitOfWork.TicketsRepository.Update(id,newTicket);
            }
            else
            {
                throw new Exception($"Ticket with this id {id} has not been created");
            }
        }
    }
}
