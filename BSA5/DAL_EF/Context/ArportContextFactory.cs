using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL_EF.Context
{
    class ArportContextFactory : IDesignTimeDbContextFactory<AirportContext>
    {
        public AirportContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AirportContext>();
            optionsBuilder.UseSqlServer("Data Source=a1");

            return new AirportContext(optionsBuilder.Options);
        }
    }
}
