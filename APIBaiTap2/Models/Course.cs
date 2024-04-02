namespace APIBaiTap2.Models
{
    public class Course
    {
        public int CourseID { get; set; } // Khóa chính
        public string CourseName { get; set; }
        public string Description { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
