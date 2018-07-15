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
    [Route("/stewardess")]
    public class StewardessController : Controller
    {
        IService<StewardessesDTO> stewadressService;

        public StewardessController(IService<StewardessesDTO> serv)
        {
            stewadressService = serv;
        }


        // GET: /stewadress
        [HttpGet]
        public string Get()
        {
            var list = stewadressService.GetAll();
            string res = JsonConvert.SerializeObject(list);
            return res;
        }

        //GET: /stewadress/:id/name
        [HttpGet("{id}/name")]
        public string GetName(int id)
        {
            try
            {
                var pilot = (stewadressService.GetById(id)).Name;
                return $"This pilot has name {pilot}";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        //GET: /stewadress/:id/surname
        [HttpGet("{id}/surname")]
        public string GetSurname(int id)
        {
            try
            {
                var pilot = (stewadressService.GetById(id)).Surname;
                return $"This pilot has surname {pilot}";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        //GET: /stewadress/:id/date
        [HttpGet("{id}/date")]
        public string GetDate(int id)
        {
            try
            {
                var pilot = (stewadressService.GetById(id)).DateOfBirth;
                return $"This pilot has date of birtth {pilot}";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        //GET: /stewadress/:id
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                var stewadress = stewadressService.GetById(id);
                string res = JsonConvert.SerializeObject(stewadress);
                return res;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        //DELETE stewadress/id
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                stewadressService.Delete(id);
                return $"Deleted element with {id} id";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //DELETE stewadress
        [HttpDelete]
        public string DeleteAll()
        {
            stewadressService.DeleteAll();
            return "All data deleted";
        }

        //POST
        // {
        //   "Id": 1,
        //   "Name": 0,
        //   "Surname": 0
        //   "DateOfBirth": "1980-09-13 12:13:14",
        //}
        [HttpPost]
        public string CreateNewElem([FromBody] StewardessesDTO element)
        {
            if (!ModelState.IsValid)
                return "Not valid data";
            try
            {
                stewadressService.Create(element);
                return "Created the new element";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // PUT stewadress/id
        // {
        //   "Id": 1,
        //   "Name": 0,
        //   "Surname": 0
        //   "DateOfBirth": "1980-09-13 12:13:14",
        //}
        [HttpPut("{id}")]
        public string UpdateElem(int id, [FromBody] StewardessesDTO element)
        {
            if (!ModelState.IsValid)
                return "Not valid data";
            try
            {
                stewadressService.Update(id, element);
                return "Updated new elemnt";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }

}
