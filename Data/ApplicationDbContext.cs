using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Department>().HasData(

                new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "Computer Science"
                },

                new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "Information Technology"
                },

                new Department
                {
                    DepartmentId = 3,
                    DepartmentName = "Electronics and Communication"
                },

                new Department
                {
                    DepartmentId = 4,
                    DepartmentName = "Mechanical Engineering"
                },

                new Department
                {
                    DepartmentId = 5,
                    DepartmentName = "Civil Engineering"
                },

                new Department
                {
                    DepartmentId = 6,
                    DepartmentName = "Artificial Intelligence"
                },

                new Department
                {
                    DepartmentId = 7,
                    DepartmentName = "Data Science"
                }

            );
        }
    }
}