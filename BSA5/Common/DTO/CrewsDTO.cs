using DAL_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.DTO
{
    public class CrewsDTO
    {
        public int Cid { get; set; }

        public PilotsDTO Pilot { get; set; }

        public List<StewardessesDTO> StewardessList { get; set; }
    }
}
