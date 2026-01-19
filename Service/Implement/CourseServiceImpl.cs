using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;
using StudentPortal.Models;

namespace StudentPortal.Service.Implement
{
    public class CourseServiceImpl : ICourseService
    {
        private readonly ApplicationDbContext _context;
        public CourseServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllCourses()
        {
            var allCourse = await _context.Courses.ToListAsync();
            return allCourse;
        }

        public async Task<Course> GetCourseById(string id)
        {
            return await _context.Courses.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Course> CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course> DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return course;
        }
    }
}