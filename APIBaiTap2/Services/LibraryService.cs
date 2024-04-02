using APIBaiTap2.Models;
using APIBaiTap2.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBaiTap2.Services;

namespace REST_API_TEMPLATE.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly SchoolDbContext _db;

        public LibraryService(SchoolDbContext db)
        {
            _db = db;
        }

        #region Students

        public async Task<List<Student>> GetStudentsAsync()
        {
            try
            {
                return await _db.Students.ToListAsync();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                return null;
            }
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            try
            {
                return await _db.Students.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                return null;
            }
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            try
            {
                await _db.Students.AddAsync(student);
                await _db.SaveChangesAsync();
                return await _db.Students.FindAsync(student.StudentID); // Lấy ID tự động từ DB
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                return null;
            }
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            try
            {
                _db.Entry(student).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return student;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                return null;
            }
        }

        public async Task<(bool, string)> DeleteStudentAsync(Student student)
        {
            try
            {
                var dbStudent = await _db.Students.FindAsync(student.StudentID);

                if (dbStudent == null)
                {
                    return (false, "Student could not be found.");
                }

                _db.Students.Remove(student);
                await _db.SaveChangesAsync();

                return (true, "Student got deleted.");
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        #endregion Students

        #region Courses

        public async Task<List<Course>> GetCoursesAsync()
        {
            try
            {
                return await _db.Courses.ToListAsync();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                return null;
            }
        }

        public async Task<Course> GetCourseAsync(int id)
        {
            try
            {
                return await _db.Courses.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                return null;
            }
        }

        public async Task<Course> AddCourseAsync(Course course)
        {
            try
            {
                await _db.Courses.AddAsync(course);
                await _db.SaveChangesAsync();
                return await _db.Courses.FindAsync(course.CourseID); // Lấy ID tự động từ DB
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                return null;
            }
        }

        public async Task<Course> UpdateCourseAsync(Course course)
        {
            try
            {
                _db.Entry(course).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return course;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                return null;
            }
        }

        public async Task<(bool, string)> DeleteCourseAsync(Course course)
        {
            try
            {
                var dbCourse = await _db.Courses.FindAsync(course.CourseID);

                if (dbCourse == null)
                {
                    return (false, "Course could not be found.");
                }

                _db.Courses.Remove(course);
                await _db.SaveChangesAsync();

                return (true, "Course got deleted.");
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        #endregion Courses
    }
}
