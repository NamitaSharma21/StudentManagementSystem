using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; } = string.Empty;
    }
}