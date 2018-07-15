using DAL_EF.Models;
using System;
namespace Common.DTO
{
    public class DeparturesDTO
    {
        public int Id { get; set; }

        public int Flight { get; set; }
        public DateTime DepartureDate { get; set; }
        public int Crew { get; set; }
        public int Aircraft { get; set; }
    }
}
