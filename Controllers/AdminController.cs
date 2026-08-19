using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ==========================
        // Dashboard
        // ==========================
        public IActionResult Dashboard(string search)
        {
            var students = _context.Students
                                .Where(s => s.Role == "Student")
                                .Include(s => s.Department)
                                .AsQueryable();


            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(s =>
                    s.Name.Contains(search) ||
                    s.Username.Contains(search) ||
                    s.Course.Contains(search) ||
                    s.Department.DepartmentName.Contains(search)
                );
            }


            return View(students.ToList());
        }

        // ==========================
        // Add Student Page
        // ==========================
        [HttpGet]
        public IActionResult AddStudent()
        {
            ViewBag.Departments = _context.Departments.ToList();
            return View();
        }

        // ==========================
        // Add Student
        // ==========================
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            student.Role = "Student";

            // Remove Role validation error because it is auto-generated
            ModelState.Remove("Role");


            if (!ModelState.IsValid)
            {
                ViewBag.Departments = _context.Departments.ToList();
                return View(student);
            }


            _context.Students.Add(student);
            _context.SaveChanges();


            return RedirectToAction("Dashboard");
        }
        // ==========================
        // Student Details
        // ==========================
        public IActionResult StudentDetails(int id)
        {
            var student = _context.Students
                                  .Include(s => s.Department)
                                  .FirstOrDefault(s => s.ID == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // ==========================
        // Edit Student (GET)
        // ==========================
        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return NotFound();

            ViewBag.Departments = _context.Departments.ToList();

            return View(student);
        }

        // ==========================
        // Edit Student (POST)
        // ==========================
        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = _context.Departments.ToList();
                return View(student);
            }

            student.Role = "Student";

            _context.Students.Update(student);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }

        // ==========================
        // Delete Student
        // ==========================
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }
    }
}