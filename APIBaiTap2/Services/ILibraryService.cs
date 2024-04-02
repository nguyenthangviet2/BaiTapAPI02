using APIBaiTap2.Models;

namespace APIBaiTap2.Services
{
    public interface ILibraryService
    {
        // Student Services
        Task<List<Student>> GetStudentsAsync(); // GET All Students
        Task<Student> GetStudentAsync(int id); // GET Single Student
        Task<Student> AddStudentAsync(Student student); // POST New Student
        Task<Student> UpdateStudentAsync(Student student); // PUT Student
        Task<(bool, string)> DeleteStudentAsync(Student student); // DELETE Student

        // Course Services
        Task<List<Course>> GetCoursesAsync(); // GET All Courses
        Task<Course> GetCourseAsync(int id); // GET Single Course
        Task<Course> AddCourseAsync(Course course); // POST New Course
        Task<Course> UpdateCourseAsync(Course course); // PUT Course
        Task<(bool, string)> DeleteCourseAsync(Course course); // DELETE Course
    }

}
