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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PL.Controllers
{
    [Route("/departures")]
    public class DeparturesController : Controller
    {
        IService<DeparturesDTO> departureService;

        public DeparturesController(IService<DeparturesDTO> serv)
        {
            departureService = serv;
        }


        // GET: /departures
        [HttpGet]
        public string Get()
        {
            var list = departureService.GetAll();
            string res = JsonConvert.SerializeObject(list);
            return res;
        }

        //GET: /departures/:id
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                var crew = departureService.GetById(id);
                string res = JsonConvert.SerializeObject(crew);
                return res;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }



        //DELETE departures/id
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                departureService.Delete(id);
                return $"Deleted element with {id} id";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //DELETE departures
        [HttpDelete]
        public string DeleteAll()
        {
            departureService.DeleteAll();
            return "All data deleted";
        }

        //POST
        // {
        //   "Id": 1,
        //   "FlightID":2,
        //   "DepartureDate": "1980-09-13 12:13:14",
        //   "CrewId": 1,
        //   "AircraftId": 1
        //}
        [HttpPost]
        public string CreateNewElem([FromBody] DeparturesDTO element)
        {
            if (!ModelState.IsValid)
                return "Not valid data";
            try
            {
                departureService.Create(element);
                return "Created the new element";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // PUT departures/id
        // {
        //   "Id": 1,
        //   "FlightID":2,
        //   "DepartureDate": "1980-09-13 12:13:14",
        //   "CrewId": 1,
        //   "AircraftId": 1
        //}
        [HttpPut("{id}")]
        public string UpdateElem(int id, [FromBody] DeparturesDTO element)
        {
            if (!ModelState.IsValid)
                return "Not valid data";
            try
            {
                departureService.Update(id, element);
                return "Updated new elemnt";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
