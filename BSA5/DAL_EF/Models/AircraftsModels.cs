using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_EF.Models
{
    public class AircraftsModels
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AMid { get; set; }
        public string ModelName { get; set; }
        public int PlacesCount { get; set; }
        public int AircraftTonnage { get; set; }
    }
}
