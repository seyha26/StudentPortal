using StudentPortal.Models;

namespace StudentPortal.Service
{
    public interface IEnrollmentService
    {
        Task<List<Enrollment>> GetAllEnrollments ();
        Task<Enrollment?> GetEnrollmentById (string id);
        Task<Enrollment> CreateEnrollment (Enrollment enrollment);
        Task<Enrollment> UpdateEnrollment (Enrollment enrollment);
        Task<Enrollment> DeleteEnrollment (Enrollment enrollment);
        Task<List<Enrollment>> GetEnrollmentsByStudentId (string studentId);
        Task<List<Enrollment>> GetEnrollmentsByCourseId (string courseId);
    }
}