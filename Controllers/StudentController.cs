using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }


        // Student Profile
        public IActionResult MyProfile()
        {
            int? studentId = HttpContext.Session.GetInt32("StudentId");

            if(studentId == null)
            {
                return RedirectToAction("Login", "Account");
            }


            var student = _context.Students
                                  .Include(s => s.Department)
                                  .FirstOrDefault(s => s.ID == studentId);


            if(student == null)
            {
                return NotFound();
            }


            return View(student);
        }
    }
}