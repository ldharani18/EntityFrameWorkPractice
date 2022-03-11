using EntityFrameWorkPractice.Models;
using EntityFrameWorkPractice.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameWorkPractice.Controllers
{
    public class HomeController : Controller
    { 

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.FirstName = "Dharani";
            ViewBag.LastName = "Lakshmanan";
            ViewBag.Address = "Coimbatore";
            return View();
        }
        public ActionResult GetStudent()
        {
            List<Student> students = new List<Student>()
            {
                new Student(){  StudentID =1,FirstName = "Albert",LastName = "Einstein",Age = 17,City = "London",Marks = 50 },
                new Student(){  StudentID =2,FirstName = "Bill",LastName = "Gates",Age = 17,City = "Paris",Marks = 98 },
                new Student(){  StudentID =3,FirstName = "Charles",LastName = "Babbage",Age = 18,City = "Mumbai",Marks = 64 },
                new Student(){  StudentID =4,FirstName = "Darwin",LastName = "Thomas",Age = 17,City = "Chennai",Marks = 81 },
                new Student(){  StudentID =5,FirstName = "Elizabeth",LastName = "Queen",Age = 22,City = "Coimbatore",Marks = 79 }
            };
            ViewBag.Student = students;
            return View();
        }
        public ActionResult GetStudentViewModel()
        {
            var student=new Student() { StudentID = 1, FirstName = "Albert", LastName = "Einstein", Age = 17, City = "London", Marks = 50 };
            var subjects = new List<Subject>()
            {
                new Subject() { Id=1, Name="HTML"},
                new Subject() { Id=2, Name="CSS"},
                new Subject() { Id=3, Name="JavaScript"}
            };
            var viewmodel = new StudentViewModel()
            {
                Student=student,
                Subjects=subjects
            };

            return View(viewmodel);
        }
        public ActionResult EditStudent(int id)
        {
            return Content("Student ID " + id);
        }
        //Range, Min , Max and Regex for regular expression
        //Datatypes
        [Route("Home/passingyear/{month:int:range(1,12)}/{year:int:min(1990)}")]
        public ActionResult ByPassingYear(int month,int year)
        {
            return Content("Month: " + month + " Year: " + year);
        }
    }
}