using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Models;
using System.Linq;

namespace StudentManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ==========================
        // Register Page
        // ==========================
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // ==========================
        // Register Submit
        // ==========================
        [HttpPost]
        public IActionResult Register(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            // Username already exists
            var existingUser = _context.Students
                .FirstOrDefault(x => x.Username == student.Username);

            if (existingUser != null)
            {
                ViewBag.Error = "Username already exists.";
                return View(student);
            }

            // Default Role (Admin)
            if (string.IsNullOrEmpty(student.Role))
            {
                student.Role = "Admin";
            }

            _context.Students.Add(student);
            _context.SaveChanges();

            TempData["Success"] = "Registration Successful. Please Login.";

            return RedirectToAction("Login");
        }

        // ==========================
        // Login Page
        // ==========================
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // ==========================
        // Login Submit
        // ==========================
        [HttpPost]
        public IActionResult Login(string username, string password, string role)
        {
            var user = _context.Students.FirstOrDefault(x =>
                    x.Username == username &&
                    x.Password == password &&
                    x.Role == role);

            if (user == null)
            {
                ViewBag.Error = "Invalid Username, Password or Role.";
                return View();
            }

            // Session
            HttpContext.Session.SetInt32("StudentId", user.ID);
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Role", user.Role);

            // Redirect according to Role
            // Redirect according to Role
            if (user.Role == "Admin")
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
            }

        // ==========================
        // Logout
        // ==========================
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}