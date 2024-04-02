namespace APIBaiTap2.Models
{
    public class Student
    {
        public int StudentID { get; set; } // Khóa chính
        public string Name { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
