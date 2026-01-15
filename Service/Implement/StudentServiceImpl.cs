using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;
using StudentPortal.Models;

namespace StudentPortal.Service.Implement
{
    public class StudentServiceImpl : IStudentService
    {
        private readonly ApplicationDbContext _context;
        public StudentServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var allStudent = await _context.Students.ToListAsync();
            return allStudent;
        }

        public async Task<Student> GetStudentById(string id)
        {
            return await _context.Students.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Student> CreateStudent(Student Student)
        {
            _context.Students.Add(Student);
            await _context.SaveChangesAsync();
            return Student;
        }

        public async Task<Student> UpdateStudent(Student Student)
        {
            _context.Students.Update(Student);
            await _context.SaveChangesAsync();
            return Student;
        }

        public async Task<Student> DeleteStudent(Student Student)
        {
            _context.Students.Remove(Student);
            await _context.SaveChangesAsync();
            return Student;
        }
    }
}