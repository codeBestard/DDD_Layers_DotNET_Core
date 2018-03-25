using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OSR.Application.ReadModels;
using OSR.Application.Services.Course;
using OSR.Web.Api.Models.Course;

namespace OSR.Web.Api.Controllers
{
    [Route("[controller]")]
    public class CourseController : Controller
    {
        private readonly ICouseService _courseService;

        public CourseController( ICouseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet( "{id}" )]
        public async Task<CourseRM> Get(Guid id)
        {
            var course = await _courseService.GetByIdAsync( id );
            return course;
        }

        [HttpPost("addstudent")]
        public async Task<IActionResult> AddStudent([FromBody]AddStudentCommand addStudentCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var course = await _courseService.AddStudentToCourseAsync(addStudentCommand.CourseId,
                                                                        addStudentCommand.StudentId);
            return Ok(course);
        }


        [HttpPost("removestudent")]
        public async Task<IActionResult> RemoveStudent([FromBody] RemoveStudentCommand removeStudentCommand)
        {
            await _courseService.RemoveStudentFromCourseAsync(removeStudentCommand.CourseId,
                                                                removeStudentCommand.StudentId);
            return Ok();
        }
    }
}
