using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StudentPortal.Models
{
    public class Course{
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString(); 
        public string Name { get; set; }
        public int Credits { get; set; }
        public List<Enrollment> Entrollments { get; set; } = new();
    }
}