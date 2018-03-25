using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace OSR.Web.Api.Extensions.Swagger
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerBasic( this IServiceCollection services )
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc( "v1" , new Info
                    {
                        Contact = new Contact { Email = "test@test.com" , Name = "test" , Url = "http://localhost" } ,
                        Description = "Api with Swashbuckle.AspNetCore.Swagger" ,
                        TermsOfService = "None" ,
                        Title = "Api with Swashbuckle"
                    } );
                }
            );
        }
    }
}
