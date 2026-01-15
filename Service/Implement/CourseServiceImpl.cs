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

        public async Task<Enrollment> CreateEnrollment(Enrollment Enrollment)
        {
            _context.Enrollments.Add(Enrollment);
            await _context.SaveChangesAsync();
            return Enrollment;
        }

        public async Task<Enrollment> UpdateEnrollment(Enrollment Enrollment)
        {
            _context.Enrollments.Update(Enrollment);
            await _context.SaveChangesAsync();
            return Enrollment;
        }

        public async Task<Enrollment> DeleteEnrollment(Enrollment Enrollment)
        {
            _context.Enrollments.Remove(Enrollment);
            await _context.SaveChangesAsync();
            return Enrollment;
        }
    }
}