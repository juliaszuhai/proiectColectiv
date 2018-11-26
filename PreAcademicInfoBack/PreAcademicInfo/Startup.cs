using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using PreAcademicInfo.Models;

namespace PreAcademicInfo
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
            
            services.AddCors();
            services.AddMvc();

            services.AddDbContext<StudentContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("StudentContext")));

            services.AddDbContext<UsersContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("UsersContext")));

            services.AddDbContext<AdminsContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AdminsContext")));

            services.AddDbContext<TeachersContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TeachersContext")));

            services.AddDbContext<DepartmentsContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DepartmentsContext")));

            services.AddDbContext<SpecializariContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SpecializariContext")));

            services.AddDbContext<DisciplineContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DisciplineContext")));
        }

       
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors();
            app.UseMvc();
        }
    }
}
