using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course is required")]
        public string Course { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mobile Number is required")]
        public string MobileNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Semester is required")]
        public int Semester { get; set; }

        [Required(ErrorMessage = "CGPA is required")]
        [Column(TypeName = "decimal(4,2)")]
        public decimal CGPA { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Hometown is required")]
        public string Hometown { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}