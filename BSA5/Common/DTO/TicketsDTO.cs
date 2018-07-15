using DAL_EF.Models;
using System;
namespace Common.DTO
{
    public class TicketsDTO
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public Flights Flight { get; set; }
    }
}
