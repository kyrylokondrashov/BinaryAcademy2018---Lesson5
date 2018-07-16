using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL_EF.Context;
using BL.Interfaces;
using BL.Services;
using Common.DTO;
using DAL_EF.UnitOfWork;
using DAL_EF.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using DAL_EF.Models;

namespace PL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IService<FlightsDTO>, FlightsService>();
            services.AddTransient<IService<TicketsDTO>, TicketsServices>();
            services.AddTransient<IService<StewardessesDTO>, StewardessesService>();
            services.AddTransient<IService<PilotsDTO>, PilotsService>();
            services.AddTransient<IService<AircraftsDTO>, AircraftsService>();
            services.AddTransient<IService<CrewsDTO>, CrewsService>();
            services.AddTransient<IService<AircraftsModelsDTO>, AircraftsModelsService>();
            services.AddTransient<IService<DeparturesDTO>, DeparturesServices>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<AirportContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("b3")));
            services.AddMvc();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AircraftsDTO, Aircrafts>();
                cfg.CreateMap<Aircrafts, AircraftsDTO>();

                cfg.CreateMap<TicketsDTO, Tickets>();
                cfg.CreateMap<Tickets, TicketsDTO>();

                cfg.CreateMap<PilotsDTO, Pilots>();
                cfg.CreateMap<Pilots, PilotsDTO>();

                cfg.CreateMap<StewardessesDTO, Stewardesses>().ForMember(x => x.Id, opt => opt.Ignore());
                cfg.CreateMap<Stewardesses, StewardessesDTO>();

                cfg.CreateMap<CrewsDTO, Crews>().ForMember(x => x.Id, opt => opt.Ignore());
                cfg.CreateMap<Crews, CrewsDTO>();

                cfg.CreateMap<AircraftsModelsDTO, AircraftsModels>().ForMember(x => x.Id, opt => opt.Ignore());
                cfg.CreateMap<AircraftsModels, AircraftsModelsDTO>();

                cfg.CreateMap<DeparturesDTO, Departures>();
                cfg.CreateMap<Departures, DeparturesDTO>();

                cfg.CreateMap<FlightsDTO, Flights>();
                cfg.CreateMap<Flights, FlightsDTO>();

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
