using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Interfaces;
using Common.DTO;
using BL.Services;
using DAL_EF.Interfaces;
using DAL_EF.UnitOfWork;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PL.Controllers
{
    [Route("/aircraftsModel")]
    public class AircratsModelsController : Controller
    {
        IService<AircraftsModelsDTO> aircratsModelsService;

        public AircratsModelsController(IService<AircraftsModelsDTO> serv)
        {
            aircratsModelsService = serv;
        }


        // GET: /aircraftsModel
        [HttpGet]
        public string Get()
        {
            var list = aircratsModelsService.GetAll();
            string res = JsonConvert.SerializeObject(list);
            return res;
        }

        //GET: /aircraftsModel/:id
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                var crew = aircratsModelsService.GetById(id);
                string res = JsonConvert.SerializeObject(crew);
                return res;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        //GET: /aircraftsModel/:id/aircraftTypeModel
        [HttpGet("{id}/aircraftTypeModel")]
        public string GetModel(int id)
        {
            try
            {
                var crew = (aircratsModelsService.GetById(id)).ModelName;
                return $"Aircraft model name is {crew}.";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        //GET: /aircraftsModel/:id/places
        [HttpGet("{id}/places")]
        public string GetPlaces(int id)
        {
            try
            {
                var crew = (aircratsModelsService.GetById(id)).PlacesCount;
                return $"Aircraft model has {crew} seats.";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        //GET: /aircraftsModel/:id/weight
        [HttpGet("{id}/weight")]
        public string GetWeight(int id)
        {
            try
            {
                var crew = (aircratsModelsService.GetById(id)).AircraftTonnage;
                return $"Aircraft model wieght is {crew}.";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        //DELETE aircraftsModel
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                aircratsModelsService.Delete(id);
                return $"Deleted element with {id} id";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //DELETE aircraftsModel
        [HttpDelete]
        public string DeleteAll()
        {
            aircratsModelsService.DeleteAll();
            return "All data deleted";
        }

        //POST
        // {
        //   "Id": 1,
        //   "ModelName": "Tytyty,
        //   "PlaceCount": 100,
        //   "AircraftTonnage": 200
        //}
        [HttpPost]
        public string CreateNewElem([FromBody] AircraftsModelsDTO element)
        {
            if (!ModelState.IsValid)
                return "Not valid data";
            try
            {
                aircratsModelsService.Create(element);
                return "Created the new element";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // PUT aircraftsModel/id
        // {
        //   "Id": 1,
        //   "ModelName": "Tytyty,
        //   "PlaceCount": 100,
        //   "AircraftTonnage": 200
        //}
        [HttpPut("{id}")]
        public string UpdateElem(int id, [FromBody] AircraftsModelsDTO element)
        {
            if (!ModelState.IsValid)
                return "Not valid data";
            try
            {
                aircratsModelsService.Update(id, element);
                return "Updated new elemnt";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }

}

