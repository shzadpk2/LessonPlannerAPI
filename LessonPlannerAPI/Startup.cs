using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LessonPlanner.Common;
using LessonPlanner.Repositories.IRepository;
using LessonPlanner.Repositories.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LessonPlannerAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            GetConnectionString();
        }

        public IConfiguration Configuration { get; }

        private void GetConnectionString()
        {
            DbHelper.DbConnectionString = Configuration.GetConnectionString("Development");
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ILessonPlannerRepository, LessonPlannerRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ISubjectRepository, SubjectRespository>();
            services.AddSingleton<IGradeRepository, GradeRepository>();
            services.AddSingleton<IQuizMakerRepository, QuizMakeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=LessonPlanner}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
