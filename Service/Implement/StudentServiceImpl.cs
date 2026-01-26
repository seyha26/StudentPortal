using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPartal.Exceptions;

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
            if(allStudent == null)
            {
                throw new WebException("400", "No student record.");
            }
            return allStudent;
        }

        public async Task<Student> GetStudentById(string id)
        {
            Student student = await _context.Students.SingleOrDefaultAsync(s=>s.Id == id);
            if(student == null)
            {
                throw new WebException("400", "Student not found.");
            }
            return student;
        }

        public async Task<Student> CreateStudent(Student Student)
        {
            if(Student == null)
            {
                throw new WebException("400", "Student is null.");
            }
            _context.Students.Add(Student);
            await _context.SaveChangesAsync();
            return Student;
        }

        public async Task<Student> UpdateStudent(Student Student)
        {
            if(Student == null)
            {
                throw new WebException("400", "Student is null.");
            }
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