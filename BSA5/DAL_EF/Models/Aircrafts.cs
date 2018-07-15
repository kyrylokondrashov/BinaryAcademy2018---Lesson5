using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_EF.Models
{
    public class Aircrafts
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string AircraftName { get; set; }
        public AircraftsModels AircraftsModels { get; set; }
        public DateTime AircraftBuildDate { get; set; }
        public long AircraftExpluatationSpan { get; set; }
        public List<Tickets> Tickets { get; set; }
    }
}
