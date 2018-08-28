using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OSR.Application.EventHandlers.Course;
using OSR.Application.Services.Course;
using OSR.Domain.Repositories;
using OSR.Infrastructure.Email;
using OSR.Infrastructure.Persistance.Sql;
using OSR.Infrastructure.Persistance.Sql.Repositories;
using System;
using Microsoft.AspNetCore.Mvc;
using OSR.Web.Api.Extensions.Swagger;

namespace OSR.Web.Api
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
            services.AddMvc().SetCompatibilityVersion( CompatibilityVersion.Version_2_1 );

            // Add Entityframework
            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<OSRDbContext>( options =>
            {
                options.UseSqlServer( Configuration.GetConnectionString( "OSRConnection" ) , opt =>
                {
                    opt.EnableRetryOnFailure( maxRetryCount: 3 , maxRetryDelay: TimeSpan.FromSeconds( 30 ) , errorNumbersToAdd: null ) ;
                    
                } );
            } );

            services.AddScoped<IEmailService , EmailService>();
            services.AddScoped<ICouseService , CourseService>();
            services.AddScoped<IStudentRepository , StudentRepository>();
            services.AddScoped<ICourseRepository , CourseRepository>();


            services.AddMediatR( typeof( StudentEnrolledDomainEventHandler ).Assembly );
            
            services.AddSwaggerBasic();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI( options =>
            {
                /* endpint url http://localhost:xxxx/swagger  */
                options.SwaggerEndpoint( "/swagger/v1/swagger.json" , "My API V1" );

            } );

            app.UseMvcWithDefaultRoute();
        }
    }
}
