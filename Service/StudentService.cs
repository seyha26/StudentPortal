using StudentPortal.Models;

namespace StudentPortal.Service
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents ();
        Task<Student> GetStudentById(string id);
        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<Student> DeleteStudent(Student student);
    }
}