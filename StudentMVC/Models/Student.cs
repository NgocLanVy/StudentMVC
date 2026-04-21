namespace StudentMVC.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public string? ImgUrl { get; set; }
        public string? Des { get; set; }
    }
}