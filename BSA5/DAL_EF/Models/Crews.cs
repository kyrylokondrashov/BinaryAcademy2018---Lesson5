using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_EF.Models
{
    public class Crews
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public int Cid { get; set; }
        public Pilots Pilot { get; set; }

        public List<Stewardesses> StewardessList { get; set; }
    }
}
