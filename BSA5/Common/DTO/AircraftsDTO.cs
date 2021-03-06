﻿using DAL_EF.Models;
using System;
using System.Collections.Generic;

namespace Common.DTO
{
    public class AircraftsDTO
    {
        public int Aid { get; set; }

        public string AircraftName { get; set; }
        public AircraftsModelsDTO AircraftsModels { get; set; }
        public DateTime AircraftBuildDate { get; set; }
        public long AircraftExpluatationSpan { get; set; }

    }
}
