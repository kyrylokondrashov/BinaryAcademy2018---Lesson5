using System;
using System.Collections.Generic;
using BL.Interfaces;
using AutoMapper;
using DAL_EF.Interfaces;
using DAL_EF.Models;
using Common.DTO;
namespace BL.Services
{
    public class DeparturesServices: IService<DeparturesDTO>
    {
        IUnitOfWork unitOfWork;

        public DeparturesServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(DeparturesDTO item)
        {
            var departures = unitOfWork.DeparturesRepository.GetById(item.Id);
            if (departures == null)
            {
                var newPilot = Mapper.Map<DeparturesDTO, Departures>(item);
                unitOfWork.DeparturesRepository.Create(newPilot);
            }
            else
            {
                throw new Exception($"Departures with this id {item.Id} has already been created");
            }
        }

        public void Delete(int id)
        {
            var flights = unitOfWork.DeparturesRepository.GetById(id);
            if (flights != null)
            {
                unitOfWork.DeparturesRepository.Delete(id);
            }
            else
            {
                throw new Exception($"Departures with this id {id} has not been created");
            }
        }

        public void DeleteAll()
        {
            unitOfWork.DeparturesRepository.DeleteAll();
        }


        public List<DeparturesDTO> GetAll()
        {
            var all = unitOfWork.DeparturesRepository.GetAll();
            return Mapper.Map<List<Departures>, List<DeparturesDTO>>(all);
        }

        public DeparturesDTO GetById(int id)
        {
            var departures = unitOfWork.DeparturesRepository.GetById(id);
            if (departures != null)
            {
                return Mapper.Map<Departures, DeparturesDTO>(departures);
            }
            else
            {
                throw new Exception($"Departures with this id {id} has not been created");
            }
        }

        public void Update(int id, DeparturesDTO item)
        {
            var departures = unitOfWork.DeparturesRepository.GetById(id);
            if (departures != null)
            {
                var newTicket = Mapper.Map<DeparturesDTO, Departures>(item);
                unitOfWork.DeparturesRepository.Update(id, newTicket);
            }
            else
            {
                throw new Exception($"Departures with this id {id} has not been created");
            }
        }
    }
}
