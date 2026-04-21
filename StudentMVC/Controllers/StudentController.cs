using Microsoft.AspNetCore.Mvc;
using StudentMVC.Models;
using System;
using System.Collections.Generic;

namespace StudentMVC.Controllers
{
    public class StudentController : Controller
    {
        [Route("HomeStudent")]
        [Route("Student")]
        [Route("Student/ListAll")]
        [Route("Liet-ke-danh-sach-sinh-vien")]
        public string ListAll()
        {
            return "Liệt kê danh sách sinh viên";
        }
        public ContentResult Index()
        {
            return new ContentResult()
            {
                Content = "Welcome to Student page",
                ContentType = "text/plain"
            };
        }
        [Route("File/Download-file")]
        public FileResult DownloadPdf()
        {
            return File("/linq.pdf", "application/pdf");
        }

        [Route("Student/List")]
        public IActionResult ListOnlyStudent(int? id)
        {
            if (!id.HasValue)
                return BadRequest("ID không được rỗng");

            if (id < 1 || id > 1000)
                return NotFound("Không tìm thấy sinh viên");

            return Content("Thong tin sinh vien: " + id, "text/html");
        }

        [Route("Edit-student")]
        public IActionResult EditStudent()
        {
            return LocalRedirect("~/Home/Index");
        }

        public string AddStudent()
        {
            return "Thêm thông tin một sinh viên";
        }

        public string DelStudent()
        {
            return "Xóa thông tin một sinh viên";
        }
        public IActionResult ListStudents()
        {
            List<Student> list = new List<Student>()
            {
                new Student { Id = 1, Name = "Tèo", Age = 20, Gender = true, Des = "Sinh viên CNTT" },
                new Student { Id = 2, Name = "Tý", Age = 19, Gender = false, Des = "Sinh viên Kinh tế" },
                new Student { Id = 3, Name = "Tủn", Age = 21, Gender = true, Des = "Sinh viên Ngoại ngữ" }
            };

            return View(list);
        }
    }
}