using System;
using System.Collections.Generic;
using BL.Interfaces;
using AutoMapper;
using DAL_EF.Interfaces;
using DAL_EF.Models;
using Common.DTO;
namespace BL.Services
{
    public class StewardessesService: IService<StewardessesDTO>
    {
        IUnitOfWork unitOfWork;

        public StewardessesService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(StewardessesDTO item)
        {
            var stewardesses = unitOfWork.StewardessesRepository.GetById(item.Id);
            if (stewardesses == null)
            {
                var newStewardess = Mapper.Map<StewardessesDTO, Stewardesses>(item);
                unitOfWork.StewardessesRepository.Create(newStewardess);
            }
            else
            {
                throw new Exception($"Stewardess with this id {item.Id} has already been created");
            }
        }

        public void Delete(int id)
        {
            var stewardesses = unitOfWork.StewardessesRepository.GetById(id);
            if (stewardesses != null)
            {
                unitOfWork.StewardessesRepository.Delete(id);
            }
            else
            {
                throw new Exception($"Stewardess with this id {id} has not been created");
            }
        }

        public void DeleteAll()
        {
            unitOfWork.StewardessesRepository.DeleteAll();
        }


        public List<StewardessesDTO> GetAll()
        {
            var all = unitOfWork.StewardessesRepository.GetAll();
            return Mapper.Map<List<Stewardesses>, List<StewardessesDTO>>(all);
        }

        public StewardessesDTO GetById(int id)
        {
            var stewardesses = unitOfWork.StewardessesRepository.GetById(id);
            if (stewardesses != null)
            {
                return Mapper.Map<Stewardesses, StewardessesDTO>(stewardesses);
            }
            else
            {
                throw new Exception($"Stewardesses with this id {id} has not been created");
            }
        }

        public void Update(int id, StewardessesDTO item)
        {
            var stewardesses = unitOfWork.StewardessesRepository.GetById(id);
            if (stewardesses != null)
            {
                var newTicket = Mapper.Map<StewardessesDTO, Stewardesses>(item);
                unitOfWork.StewardessesRepository.Update(id,newTicket);
            }
            else
            {
                throw new Exception($"Stewardesses with this id {id} has not been created");
            }
        }
    }
}
