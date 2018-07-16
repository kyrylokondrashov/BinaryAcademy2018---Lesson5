using System;
namespace Common.DTO
{
    public class PilotsDTO
    {
        public int Pid { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Experience { get; set; }
    }
}
