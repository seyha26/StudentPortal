using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;
using StudentPortal.Models;

namespace StudentPortal.Service.Implement
{
    public class EnrollmentServiceImpl : IEnrollmentService
    {
        private readonly ApplicationDbContext _context;
        public EnrollmentServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Enrollment>> GetAllEnrollments()
        {
            var allEnrollment = await _context.Enrollments.ToListAsync();
            return allEnrollment;
        }

        public async Task<Enrollment> GetEnrollmentById(string id)
        {
            return await _context.Enrollments.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Enrollment> CreateEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
        }

        public async Task<Enrollment> UpdateEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
        }

        public async Task<Enrollment> DeleteEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
        }

        public async Task<List<Enrollment>> GetEnrollmentsByStudentId(string studentId)
        {
            return await _context.Enrollments.Where(e=> e.StudentId == studentId).ToListAsync();
        }

        public async Task<List<Enrollment>> GetEnrollmentsByCourseId(string courseId)
        {
            return await _context.Enrollments.Where(e => e.CourseId == courseId).ToListAsync();
        }
    }
}