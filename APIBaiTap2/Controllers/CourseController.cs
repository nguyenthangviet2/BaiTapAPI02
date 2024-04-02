using APIBaiTap2.Models;
using APIBaiTap2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace   APIBaiTap2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public CourseController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _libraryService.GetCoursesAsync();
            if (courses == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No courses in database.");
            }

            return StatusCode(StatusCodes.Status200OK, courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            Course course = await _libraryService.GetCourseAsync(id);

            if (course == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No course found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, course);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> AddCourse(Course course)
        {
            var dbCourse = await _libraryService.AddCourseAsync(course);

            if (dbCourse == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{course.CourseName} could not be added.");
            }

            return CreatedAtAction("GetCourse", new { id = course.CourseID }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Course course)
        {
            if (id != course.CourseID)
            {
                return BadRequest();
            }

            Course dbCourse = await _libraryService.UpdateCourseAsync(course);

            if (dbCourse == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{course.CourseName} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _libraryService.GetCourseAsync(id);
            (bool status, string message) = await _libraryService.DeleteCourseAsync(course);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, course);
        }
    }
}
