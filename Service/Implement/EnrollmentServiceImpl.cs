using Microsoft.EntityFrameworkCore;
using StudentPartal.Exceptions;
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
            if(allEnrollment == null)
            {
                throw new WebException("400", "No enrollment record.");
            }
            return allEnrollment;
        }

        public async Task<Enrollment> GetEnrollmentById(string id)
        {
            Enrollment enrollment = await _context.Enrollments.SingleOrDefaultAsync(e=>e.Id == id);
            if(enrollment == null)
            {
                throw new WebException("400", "Enrollment not found.");
            }
            return enrollment;
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
            List<Enrollment> enrollments = await _context.Enrollments.Where(e=> e.StudentId == studentId).ToListAsync();
            if(enrollments == null)
            {
                throw new WebException("400", "Enrollment not found.");
            }
            return enrollments;
        }

        public async Task<List<Enrollment>> GetEnrollmentsByCourseId(string courseId)
        {
            List<Enrollment> enrollments = await _context.Enrollments.Where(e=>e.CourseId == courseId).ToListAsync();
            if(enrollments == null)
            {
                throw new WebException("400", "Enrollment not found.");
            }
            return enrollments;
        }
    }
}