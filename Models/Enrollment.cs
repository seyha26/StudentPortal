using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.Models
{
    public class Enrollment
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string StudentId { get; set; }
        [Required]
        public string CourseId { get; set; }
        public int Grade { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}