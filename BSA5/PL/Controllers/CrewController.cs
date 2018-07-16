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
    [Route("/crew")]
    public class CrewController : Controller
    {
        IService<CrewsDTO> crewService;

        public CrewController(IService<CrewsDTO> serv)
        {
            crewService = serv;
        }


        // GET: /crew
        [HttpGet]
        public List<CrewsDTO> Get()
        {
            var list = crewService.GetAll();
            return list;
        }

        //GET: /crew/:id
        [HttpGet("{id}")]
        public CrewsDTO Get(int id)
        {
            
            var crew = crewService.GetById(id);
            return crew;

        }



        //DELETE crew/id
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                crewService.Delete(id);
                return $"Deleted element with {id} id";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //DELETE crew
        [HttpDelete]
        public string DeleteAll()
        {
            crewService.DeleteAll();
            return "All data deleted";
        }

        //POST
        // {
        //   "Id": 1,
        //   "PilotId": 0,
        //   "StewardesesId": [1,2,3]
        //}
        [HttpPost]
        public string CreateNewElem([FromBody] CrewsDTO element)
        {
            if (!ModelState.IsValid)
                return "Not valid data";
            try
            {
                crewService.Create(element);
                return "Created the new element";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // PUT crew/id
        // {
        //   "Id": 1,
        //   "PilotId": 0,
        //   "StewardesesId": [1,2,3]
        //}
        [HttpPut("{id}")]
        public string UpdateElem(int id, [FromBody] CrewsDTO element)
        {
            if (!ModelState.IsValid)
                return "Not valid data";
            try
            {
                crewService.Update(id, element);
                return "Updated new elemnt";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }

}
