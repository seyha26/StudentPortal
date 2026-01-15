using StudentPortal.Models;

namespace StudentPortal.Service
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCourses ();
        Task<Course> GetCourseById(string Id);
        Task<Course> CreateCourse(Course course);
        Task<Course> UpdateCourse(Course course);
        Task<Course> DeleteCourse(Course course);
    }
}