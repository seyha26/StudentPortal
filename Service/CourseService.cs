using StudentPortal.Models;

namespace StudentPortal.Service
{
    public interface CourseService
    {
        Task<List<Course>> GetAllCourses ();
        Course GetCourseById(int Id);
        void CreateCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(Course course);
    }
}