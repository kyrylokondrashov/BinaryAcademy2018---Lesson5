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
    [Route("/flights")]
    public class FlightsController : Controller
    {
        IService<FlightsDTO> flightService;

        public FlightsController(IService<FlightsDTO> serv)
        {
            flightService = serv;
        }


        // GET: /flights
        [HttpGet]
        public string Get()
        {
            var list = flightService.GetAll();
            string res = JsonConvert.SerializeObject(list);
            return res;
        }

        //GET: /flights/:id
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                var flight = flightService.GetById(id);
                string res = JsonConvert.SerializeObject(flight);
                return res;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

   

        //DELETE flights/id
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                flightService.Delete(id);
                return $"Deleted element with {id} id";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //DELETE flights
        [HttpDelete]
        public string DeleteAll()
        {
            flightService.DeleteAll();
            return "All data deleted";
        }

        //POST
        // {
        //   "Id": 1,
        //   "PointOfDeparture": "PointA",
        //   "DepartureDate": "1980-09-13 12:13:14",
        //   "PointOfDestination": "PointB",
        //   "TimeOfArrival": "1980-09-13 12:13:14",  
        //   "Tickets": [1,2,3]
        //}
        [HttpPost]
        public string CreateNewElem([FromBody] FlightsDTO element)
        {
            if (!ModelState.IsValid)
                return "Not valid data";
            try
            {
                flightService.Create(element);
                return "Created the new element";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // PUT flights/id
        // {
        //   "Id": 1,
        //   "PointOfDeparture": "PointA",
        //   "DepartureDate": "1980-09-13 12:13:14",
        //   "PointOfDestination": "PointB",
        //   "TimeOfArrival": "1980-09-13 12:13:14",  
        //   "Tickets": [1,2,3]
        //}
        [HttpPut("{id}")]
        public string UpdateElem(int id, [FromBody] FlightsDTO element)
        {
            if (!ModelState.IsValid)
                return "Not valid data";
            try
            {
                flightService.Update(id, element);
                return "Updated new elemnt";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
