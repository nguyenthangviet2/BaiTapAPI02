namespace APIBaiTap2.Models
{
    public class StudentCourse
    {
        public int StudentID { get; set; } // Khóa chính
        public int CourseID { get; set; } // Khóa chính
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
