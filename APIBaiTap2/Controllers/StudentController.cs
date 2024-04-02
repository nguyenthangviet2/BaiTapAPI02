using APIBaiTap2.Models;
using APIBaiTap2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIBaiTap2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public StudentController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _libraryService.GetStudentsAsync();

            if (students == null)
            {
                return StatusCode(204, "No students in database");
            }

            return StatusCode(200, students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _libraryService.GetStudentAsync(id);

            if (student == null)
            {
                return StatusCode(204, $"No student found for id: {id}");
            }

            return StatusCode(200, student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            var dbStudent = await _libraryService.AddStudentAsync(student);

            if (dbStudent == null)
            {
                return StatusCode(500, $"{student.Name} could not be added.");
            }

            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentID }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.StudentID)
            {
                return BadRequest();
            }

            var dbStudent = await _libraryService.UpdateStudentAsync(student);

            if (dbStudent == null)
            {
                return StatusCode(500, $"{student.Name} could not be updated.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _libraryService.GetStudentAsync(id);
            (bool status, string message) = await _libraryService.DeleteStudentAsync(student);

            if (!status)
            {
                return StatusCode(500, message);
            }

            return StatusCode(200, student);
        }
    }
}
