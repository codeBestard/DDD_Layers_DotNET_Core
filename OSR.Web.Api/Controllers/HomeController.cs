using System;
using Microsoft.AspNetCore.Mvc;

namespace OSR.Web.Api.Controllers
{
    [Route( "" )]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index( )
        {
            var absUrl = string.Format( "{0}://{1}/{2}" , Request.Scheme , Request.Host , "swagger" );
            
            return Content(

                content:  $"<html><body><h1>HELLO!!!</h1>Current Environment : {Environment.GetEnvironmentVariable( "ASPNETCORE_ENVIRONMENT" )}  <br><br> " +
                            $"<a href='{absUrl}'>{absUrl}</a></body></html>",

                contentType: "text/html");
        }
    }
}