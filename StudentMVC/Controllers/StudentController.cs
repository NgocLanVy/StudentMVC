using Microsoft.AspNetCore.Mvc;
using StudentMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentMVC.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> listStudents = new List<Student>()
        {
            new Student { Id = 1, Name = "Lan Vy", Age = 19, Gender = false, ImgUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQxBWVQ0dDIcviaXW6DyFP4t5IxXOHE83zGBEyGoZinHlvIkss&s", Des = "Sinh viên K21" },
            new Student { Id = 2, Name = "Ngọc Ánh", Age = 20, Gender = false, ImgUrl = "https://clipart-library.com/img/1421105.png", Des = "Sinh viên K21" },
            new Student { Id = 3, Name = "Ngọc Uyên", Age = 19, Gender = false, ImgUrl = "https://clipart-library.com/img/1421105.png", Des = "Sinh viên K21" },
            new Student { Id = 4, Name = "Văn Quân", Age = 23, Gender = true, ImgUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQxBWVQ0dDIcviaXW6DyFP4t5IxXOHE83zGBEyGoZinHlvIkss&s", Des = "Sinh viên K21" },
            new Student { Id = 5, Name = "Đức Hòa", Age = 19, Gender = true, ImgUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQxBWVQ0dDIcviaXW6DyFP4t5IxXOHE83zGBEyGoZinHlvIkss&s", Des = "Sinh viên K21" }
        };

        [Route("Student")]
        [Route("Student/ListStudents")]
        public IActionResult ListStudents()
        {
            return View(listStudents);
        }

        public IActionResult Details(int id)
        {
            var student = listStudents.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound("Không tìm thấy sinh viên!");
            return View(student);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            student.Id = listStudents.Any() ? listStudents.Max(s => s.Id) + 1 : 1;
            listStudents.Add(student);
            return RedirectToAction("ListStudents");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = listStudents.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var existingStudent = listStudents.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Age = student.Age;
                existingStudent.Gender = student.Gender;
                existingStudent.ImgUrl = student.ImgUrl;
                existingStudent.Des = student.Des;
            }
            return RedirectToAction("ListStudents");
        }
        public IActionResult Delete(int id)
        {
            var student = listStudents.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                listStudents.Remove(student);
            }
            return RedirectToAction("ListStudents");
        }

        [Route("Student/Index")]
        public ContentResult Index()
        {
            return Content("Welcome to Student page", "text/plain");
        }

        [Route("File/Download-file")]
        public FileResult DownloadPdf()
        {
            return File("/linq.pdf", "application/pdf");
        }
    }
}