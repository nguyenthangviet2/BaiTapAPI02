using Microsoft.EntityFrameworkCore;
using APIBaiTap2.Models;

namespace APIBaiTap2.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;

        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Seed()
        {
            _builder.Entity<Student>(a =>
            {
                a.HasData(new Student
                {
                    StudentID = 001,
                    Name = "J.K. Rowling",
                    
                });
                a.HasData(new Student
                {
                    StudentID = 002,
                    Name = "Walter Isaacson",
                    
                });
            });

            _builder.Entity<Course>(b =>
            {
                b.HasData(new Course
                {
                    CourseID = 01,
                    CourseName = "Harry Potter and the Sorcerer's Stone",
                    Description = "Harry Potter's life is miserable. His parents are dead and he's stuck with his heartless relatives, who force him to live in a tiny closet under the stairs.",
                    
                });
                b.HasData(new Course
                {
                        CourseID = 02,
                        CourseName = "Harry Potter and the Chamber of Secrets",
                    Description = "Ever since Harry Potter had come home for the summer, the Dursleys had been so mean and hideous that all Harry wanted was to get back to the Hogwarts School for Witchcraft and Wizardry. ",
                    
                });
                
            });
        }
    }
}