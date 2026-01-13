using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StudentPortal.Models
{
    public class Student
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString(); 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Subscribed { get; set; }
    }
}