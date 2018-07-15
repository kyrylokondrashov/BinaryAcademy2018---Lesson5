using DAL_EF.Models;
using System;
using System.Collections.Generic;
namespace Common.DTO
{
    public class CrewsDTO
    {
        public int Id { get; set; }

        public Pilots Pilot { get; set; }

        public List<Stewardesses> StewardessList { get; set; }
    }
}
