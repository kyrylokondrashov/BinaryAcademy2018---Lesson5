using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_EF.Models
{
    public class Flights
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Fid;
        public string PointOfDepartures { get; set; }
        public DateTime TimeOfDeparture { get; set; }
        public string PointOfDestination { get; set; }
        public DateTime TimeOfArrival { get; set; }

        [ForeignKey("FlihtID")]
        public List<Tickets> Tickets { get; set; }
    }
}
